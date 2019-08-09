using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Master_Arepa.Models;
using System.Net.Mail;
using System.Net;

namespace Master_Arepa.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string message)
        {
            try
            {
                sendEmail("smtp.gmail.com", 587, "cguisao@masterarepa.com", "lotero321"
                , "cguisao@masterarepa.com", email, message);
            }
            catch(Exception e)
            {
                ViewData["Error"] = e.Message;
                return View();
            }
            ViewBag.Success = "Message sent, thank you!";
            return Redirect("#subscribe");
        }

        public void sendEmail(string smtpClient, int port, string emailCredential, string passwordCredential,
            string fromEmail, string email, string message)
        {
            SmtpClient client = new SmtpClient(smtpClient, port);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(emailCredential, passwordCredential);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(email);
            mailMessage.To.Add(fromEmail);
            mailMessage.Body = message;
            mailMessage.Subject = email + " sent a message from the web";
            client.Send(mailMessage);
        }

    }
}
