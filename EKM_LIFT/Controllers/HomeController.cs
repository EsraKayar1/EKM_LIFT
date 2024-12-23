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
                    var fromAddress = new MailAddress("ekmhidroliklift@gmail.com", "EkmHidrolikLift");
                    var toAddress = new MailAddress("ekmhidroliklift@gmail.com", "Recipient");
                    string fromPassword = "hsxo ejqp kkvy cvni";
                    string subject = "EKM LIFT WebSite Mesaj";
                    string body = $"Ad: {adiniz}\nTelefon: {telefon}\nMail: {mail}\nMesaj: {mesaj}";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("ekmhidroliklift@gmail.com", "hsxo ejqp kkvy cvni")
                    };

                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }

                    ViewBag.Uyari = "Mesaj�n�z ba�ar�yla g�nderildi!";
                }
                catch (Exception ex)
                {
                    ViewBag.Uyari = $"Bir hata olu�tu: {ex.Message}";
                }
            }
            else
            {
                ViewBag.Uyari = "L�tfen t�m alanlar� doldurun.";
            }

            return View();
        }
    }

}

