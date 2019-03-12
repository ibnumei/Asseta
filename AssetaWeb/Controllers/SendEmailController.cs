using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace AssetaWeb.Controllers
{
    public class SendEmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult email()
        {
            //Instantiate mimeMessage
            var message = new MimeMessage();

            //from Address
            message.From.Add(new MailboxAddress("Undangan Berantem", "ibnu.fauziyai@gmail.com"));

            //to address
            message.To.Add(new MailboxAddress(".net email", "ibnu.mei97@gmail.com"));

            //subject
            message.Subject = ".NET Kirim Email";

            //body
            message.Body = new TextPart("plain")
            {
                Text = "Dari Ibnu Kirim Email"
            };

            using(var client = new SmtpClient())
            {
                //client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("ibnu.fauziyai@gmail.com", "ibnufauzimei");
                client.Send(message);
                client.Disconnect(true);
            }

            return View();
        }
    }
}