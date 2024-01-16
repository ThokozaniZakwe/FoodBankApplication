using FoodBankApplication.Domain;
using Microsoft.AspNetCore.Mvc;

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
            var candidates = _context.Candidates.Where(c => !c.IsDeleted).
                OrderBy(x => x.Id).Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList();
            return View(candidates);
        }

        public IActionResult Add() => View();
    }
}
