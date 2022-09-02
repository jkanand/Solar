using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SolarWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public string SendQueryEmail(string name, string emailID, string phoneNumber, string subject, string query)
        {
            string isMailSent = "";
          
            var fromEmail = new MailAddress("support@demoservices.in", "Corporate");
            var toEmail = new MailAddress(emailID);

            string body = "<br/><br/>Hello Team," +
                " <br/><br/> My Name: " + name + "<br/> Email Id: " + emailID + "<br/> Contact Number: " + phoneNumber + ""+
                " <br/><br/> " + query + "";

            MailMessage message = new MailMessage(fromEmail, toEmail);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient()
            {
                Credentials = new NetworkCredential("support@demoservices.in", "services@2020"),
                EnableSsl = false
            };
            // code in brackets above needed if authentication required 
            try
            {
                client.Send(message);
                isMailSent = "success";
            }
            catch (SmtpException ex)
            {
                isMailSent = ex.ToString();
            }
            return isMailSent;
        }
    }
}