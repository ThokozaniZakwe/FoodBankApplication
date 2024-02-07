using FoodBankApplication.Data.Models;
using FoodBankApplication.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FoodBankApplication.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ApplicationDbContext _context;
        public int PageSize = 4;

        public CandidateController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int pageNumber = 1)
        {

            ViewData["Menu"] = "candidate";
            var candidates = _context.Candidates.Where(c => !c.IsDeleted).
                OrderBy(x => x.Id).Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList();
            return View(candidates);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            ViewData["Menu"] = "candidate";
            ViewBag.Municipalities = await _context.Municipalities.Where(m => !m.IsDeleted).ToListAsync();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([Bind("Name, Surname, Gender, DOB, IDNumber, AddressLine1, AddressLine2, Province, City, ContactNumbers, PostalCode, Region, IsDisabled, Comment, HighSchoolGradeId, municipality")]Candidate candidate)
        {
            ViewData["Menu"] = "candidate";
            if (candidate == null)
            {
                return View();
            }
            try
            {

                candidate.Province = "Gauteng";
                candidate.StatusId = _context.Status.Where(s => !s.IsDeleted && s.Description == "New").FirstOrDefault().Id;
                //var highSchoolGrade = await _context.HighSchoolGrades.Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == candidate.HighShcoolGradeId);
                candidate.MunicipalityId = 2;

                await _context.Candidates.AddAsync(candidate);
                await _context.SaveChangesAsync();

                TempData["MessageToShow"] = "New Candidate Succesfully Created";
                TempData["MessageType"] = "Success";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Municipalities = await _context.Municipalities.Where(m => !m.IsDeleted).ToListAsync();
                ModelState.AddModelError("Unknown Error Occurred", ex.Message);
                TempData["MessageToShow"] = "Error Occurred";
                TempData["MessageType"] = "Error";
                return View(candidate);
            }
        }
    }

    public enum Provinces
    {
        Gauteng = 1, Mpumalanga, NorthWest, WesternCape, NorthernCape, KwaZuluNatal, FreeState, Limpopo, EasternCape
    }
}


