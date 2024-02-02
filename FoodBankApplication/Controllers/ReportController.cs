using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.WebForms;

namespace FoodBankApplication.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            var reportServerUrl = "https://localhost/reportserver";
            var reportFolder = "Reports/Userd";

            return View(reportServerUrl, reportFolder);
        }
    }
}
