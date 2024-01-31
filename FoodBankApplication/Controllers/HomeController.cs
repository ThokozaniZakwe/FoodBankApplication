using Microsoft.AspNetCore.Mvc;

namespace FoodBankApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Menu"] = "home";
            return View();
        }
    }
}
