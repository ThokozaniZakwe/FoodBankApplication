﻿using FoodBankApplication.Data.Security;
using FoodBankApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodBankApplication.Global;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using FoodBankApplication.Global.interfaces;

namespace FoodBankApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _email;

        public AccountController(ApplicationDbContext context, IEmailService email)
        {
            _context = context;
            _email = email;
        }
        [Authorize(Roles = "Admin")]
        //[Authorize(Policy = "MustBeHR")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.Where(u => !u.IsDeleted).Include(r => r.Role).ToListAsync();
            var roles = await _context.Roles.ToListAsync();
            ViewData["Roles"] = roles;
            ViewData["Menu"] = "users";
            foreach(var user in users)
            {
                if (user.Image != null)
                {
                    var img = File(user.Image, "image/jpg");
                    ViewData["image"] = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(img.FileContents));
                }
            }

            return View(users);
        }

        public async Task<IActionResult> GetImage(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if(user?.Image != null)
            {
                return File(user.Image, "image/jpg");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Menu"] = "users";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            //ViewData["Menu"] = "users";
            if (user == null)
            {
                ModelState.Clear();
                ModelState.AddModelError("Login", "Please Enter a Username and Password");
                return View();
            }

            var checkUser = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == user.Email);
            if (checkUser == null)
            {
                ModelState.Clear();
                ModelState.AddModelError("Login", "Please Enter a valid Username and Password");
                return View();
            }

            var salt = checkUser.Salt;
            if (checkUser.Password == Security.GenerateHash(user.Password + salt)) {
                var claims = new List<Claim>();
                
                var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == checkUser.RoleId);
                claims.Add(new Claim(ClaimTypes.Role , role?.Description ?? ""));
                

                checkUser.lastLogin = DateTime.Now;
                await _context.SaveChangesAsync();

                var identity = new ClaimsIdentity(claims, "CookieAuth");
                identity.AddClaim(new Claim(ClaimTypes.Name, checkUser.FullName));
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);
                ViewData["MessageToShow"] = "Login in successful";
                ViewData["MessageType"] = "Success";
                return RedirectToAction("Index", "Home", new {Message = "Login successful", MsgType = "Success"});

            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError("Login", "Invalid Username/Password");
                ViewData["MessageToShow"] = "Error trying to login";
                ViewData["MessageType"] = "Error";
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            ViewData["Menu"] = "users";
            ViewBag.Roles = new SelectList(_context.Roles, "Id", "Description");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync([Bind(include: "Name,Surname,Email,Password,RoleId")]User user)
        {
            if (user == null)
            {
                return View(user);
            }

            try
            {
                Role role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);
                string salt = Security.GenerateSalt();
                User newUser = new User
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    FullName = user.Name + " " + user.Surname,
                    Email = user.Email,
                    DateCreated = DateTime.Now,
                    Salt = salt,
                    Password = Security.GenerateHash(user.Password + salt),
                    RoleId = role?.Id ?? 1004
                };

                using (var memoryStream = new MemoryStream())
                {
                    IFormFile imgFile = Request.Form.Files[0]; //.GetFile("imgFile");
                    if (imgFile != null)
                    {
                        await imgFile.CopyToAsync(memoryStream);
                        newUser.Image = memoryStream.ToArray();
                    }
                }

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                string emailMessage = $"Your user profile has been successfully created.\n Your Username: {newUser.Email}\n Your Password: {user.Password}";
                await _email.SendAsync("tezakwe@gmail.com", newUser.Email, "New User Creation", emailMessage);
                ViewData["MessageToShow"] = "Succesfully Created";
                ViewData["MessageType"] = "Success";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.Clear();
                ModelState.AddModelError("Error", $"An error occurred trying to save user,\n {ex.Message}");
                View();
            }
            //}
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
