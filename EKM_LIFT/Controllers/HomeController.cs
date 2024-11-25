using EKM_LIFT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;

namespace EKM_LIFT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult about()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult project()
        {
            return View();
        }
        public IActionResult service()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SendEmail(string adiniz, string telefon, string mail, string mesaj)
        {
            // Örnek bir doðrulama
            if (string.IsNullOrEmpty(adiniz))
            {
                return Json(new { success = false, message = "Geçersiz veri gönderildi." });
            }

            // Baþarýlý yanýt
            return Json(new { success = true, message = "Veri baþarýyla kaydedildi!" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
