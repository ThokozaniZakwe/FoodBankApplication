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
            var candidates = _context.Candidates.Where(c => !c.IsDeleted).Include(x => x.Status).Include(x => x.HighSchoolGrade).Include(x => x.Municipality).Include(x => x.Province).Include(x => x.City).ToList();
            return View(candidates);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            ViewData["Menu"] = "candidate";
            var municipalities = await _context.Municipalities.Where(m => !m.IsDeleted).ToListAsync();
            var provinces = await _context.Provinces.Where(x => !x.IsDeleted).ToListAsync();
            var cities = await _context.Cities.Where(x => !x.IsDeleted).ToListAsync();
            ViewBag.Cities = new SelectList(cities, "Id", "Description");
            ViewBag.Provinces = new SelectList(provinces, "Id", "Description");
            ViewBag.Municipalities = new SelectList(municipalities, "Id", "Description");
            var highSchoolGrades = await _context.HighSchoolGrades.Where(x => !x.IsDeleted).ToListAsync();
            ViewBag.HighSchoolGrades = new SelectList(highSchoolGrades, "Id", "Description");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([Bind]Candidate candidate)
        {
            ViewData["Menu"] = "candidate";
            if (candidate == null)
            {
                return View();
            }
            try
            {

                var status = _context.Status.Where(s => !s.IsDeleted && s.Description == "New").FirstOrDefault();
                candidate.Status = status;
                candidate.StatusId = status.Id;

                var city = await _context.Cities.Where(x => !x.IsDeleted && x.Id == candidate.CityId).FirstOrDefaultAsync();
                candidate.City = city;
                candidate.CityId = city.Id;

                var province = await _context.Provinces.Where(x => !x.IsDeleted && x.Id == candidate.ProvinceId).FirstOrDefaultAsync();
                candidate.Province = province;
                candidate.ProvinceId = province.Id;

                var highSchoolGrade = await _context.HighSchoolGrades.Where(x => !x.IsDeleted && x.Id == candidate.HighSchoolGradeId).FirstOrDefaultAsync();
                candidate.HighSchoolGrade = highSchoolGrade;

                var municipalities = await _context.Municipalities.Where(x => !x.IsDeleted && x.Id == candidate.MunicipalityId).FirstOrDefaultAsync();
                candidate.Municipality = municipalities;
                candidate.MunicipalityId = municipalities.Id;

                var highSchoolGrades = await _context.HighSchoolGrades.Where(x => !x.IsDeleted).ToListAsync();
                ViewBag.HighSchoolGrades = new SelectList(highSchoolGrades, "Id", "Description");

                await _context.Candidates.AddAsync(candidate);
                await _context.SaveChangesAsync();

                TempData["MessageToShow"] = "New Candidate Succesfully Created";
                TempData["MessageType"] = "Success";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var municipalities = await _context.Municipalities.Where(m => !m.IsDeleted).ToListAsync();
                ViewBag.Municipalities = new SelectList(municipalities, "Id", "Description");
                ModelState.AddModelError("Unknown Error Occurred", ex.Message);
                TempData["MessageToShow"] = "Error Occurred";
                TempData["MessageType"] = "Error";
                return View(candidate);
            }
        }

        public async Task<IActionResult> GetMunicipality(string? description)
        {
            if(!String.IsNullOrEmpty(description)){
                var munipality = await _context.Municipalities.Where(x => !x.IsDeleted && x.Description == description).FirstOrDefaultAsync();
                if (munipality != null)
                {
                    return Json(munipality.Id);
                }
            }            
            return NotFound();
        }

        public async Task<IActionResult> Edit(int id)
        {
            Candidate candidate = await _context.Candidates.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            var cities = await _context.Cities.Where(x => !x.IsDeleted).ToListAsync();
            var provinces = await _context.Provinces.Where(x => !x.IsDeleted).ToListAsync();
            var municipalities = await _context.Municipalities.Where(x => !x.IsDeleted).ToListAsync();
            var highestSchoolGrades = await _context.HighSchoolGrades.Where(x => !x.IsDeleted).ToListAsync();
            var statuses = await _context.Status.Where(x => !x.IsDeleted).ToListAsync();
            ViewBag.Cities = new SelectList(cities, "Id", "Description");
            ViewBag.Provinces = new SelectList(provinces, "Id", "Description");
            ViewBag.Municipalities = new SelectList(municipalities, "Id", "Description");
            ViewBag.HighestSchoolGrades = new SelectList(highestSchoolGrades, "Id", "Description");
            ViewBag.Statuses = new SelectList(statuses, "Id", "Description");

            if (candidate != null)
            {
                return View(candidate);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Candidate candidate)
        {
            if(candidate == null)
            {
                return View(candidate);
            }
            var dbCandidate = await _context.Candidates.Where(x => !x.IsDeleted && x.Id == candidate.Id).FirstOrDefaultAsync();
            if(dbCandidate == null)
            {
                return View(candidate);
            }

            return View(dbCandidate);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Candidate candidate = await _context.Candidates.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if(candidate != null)
            {
                candidate.IsDeleted = true;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }

    public enum Provinces
    {
        Gauteng = 1, Mpumalanga, NorthWest, WesternCape, NorthernCape, KwaZuluNatal, FreeState, Limpopo, EasternCape
    }
}


