using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.WebForms;
using System.IO;
using BoldReports.DataSources;
using Microsoft.AspNetCore.Hosting;

namespace FoodBankApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment hostEnvironment;

        public HomeController(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            ViewData["Menu"] = "home";
            return View();
        }

        public IActionResult PrintPDF()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Menu"] = "privacy";
            return View();
        }
    }
}
