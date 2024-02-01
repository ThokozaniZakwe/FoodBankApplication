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
            //ViewBag.ReportServerUrl = "https://localhost/reportserver";
            //ViewBag.ReportPath = "/Reports/Users";
            //string reportPath = Path.Combine(hostEnvironment.WebRootPath, "Reports/Users.rdl");
            //string reportPath = Path.Combine(@"C:\Users\tezak\source\repos\FoodBankApplication\Reports", "Users.rdl"); //Path.Combine(hostEnvironment.ContentRootPath + "Reports/Users.rdl");
            //FileStream inputStream = new FileStream(reportPath, FileMode.Open, FileAccess.Read);
            //MemoryStream reportStream = new MemoryStream();
            //inputStream.CopyTo(reportStream);
            //reportStream.Position = 0;
            //inputStream.Close();

            return View();
        }
    }
}
