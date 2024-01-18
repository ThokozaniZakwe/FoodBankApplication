using FoodBankApplication.Data.Models;
using FoodBankApplication.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult Add()
        {
            ViewData["Menu"] = "candidate";
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([Bind("Name, Surname, Gender, DOB, IDNumber, AddressLine1, AddressLine2, Province, City, ContactNumbers, PostalCode, Region, IsDisabled, Comment")]Candidate candidate)
        {
            ViewData["Menu"] = "candidate";
            if (candidate == null)
            {
                return View();
            }

            if(!ModelState.IsValid)
            {
                return View(candidate);
            }

            return RedirectToAction(nameof(Index));
        }
    }

    public enum Provinces
    {
        Gauteng = 1, Mpumalanga, NorthWest, WesternCape, NorthernCape, KwaZuluNatal, FreeState, Limpopo, EasternCape
    }
}


