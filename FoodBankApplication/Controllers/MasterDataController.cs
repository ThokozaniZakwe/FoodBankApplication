using Microsoft.AspNetCore.Mvc;

namespace FoodBankApplication.Controllers
{
    public class MasterDataController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Menu"] = "masterdata";
            return View();
        }
    }
}
