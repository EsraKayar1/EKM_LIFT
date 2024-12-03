using EKM_LIFT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Globalization;
using System.Net.Mail;
using System.Net;
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
        public IActionResult contact(string adiniz, string telefon, string mail, string mesaj)
        {
            if (!string.IsNullOrEmpty(adiniz) && !string.IsNullOrEmpty(telefon) &&
                !string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(mesaj))
            {
                try
                {
                    var fromAddress = new MailAddress("esrakayar1313@gmail.com", "Esra Kayar");
                    var toAddress = new MailAddress("esrakayar1313@gmail.com", "Recipient");
                    const string fromPassword = "bljs abuo uxzf ewdu";
                    const string subject = "Yeni Mesaj";
                    string body = $"Ad: {adiniz}\nTelefon: {telefon}\nMail: {mail}\nMesaj: {mesaj}";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("esrakayar1313@gmail.com", "bljs abuo uxzf ewdu")
                    };

                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }

                    ViewBag.Uyari = "Mesajýnýz baþarýyla gönderildi!";
                }
                catch (Exception ex)
                {
                    ViewBag.Uyari = $"Bir hata oluþtu: {ex.Message}";
                }
            }
            else
            {
                ViewBag.Uyari = "Lütfen tüm alanlarý doldurun.";
            }

            return View();
        }
    }

}

