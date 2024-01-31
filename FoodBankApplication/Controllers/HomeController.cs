using Microsoft.AspNetCore.Mvc;

namespace FoodBankApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Menu"] = "home";
            //ViewData["MessageToShow"] = "Error in Home Page";
            //ViewData["MessageType"] = "Error";
            return View();
        }
    }
}
