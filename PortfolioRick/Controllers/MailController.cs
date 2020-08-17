using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioRick.ViewModels;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PortfolioRick.Controllers
{
    public class MailController : Controller
    {
        public async Task<IActionResult> SendContactMailAsync(MailViewModel model)
        {
			var apiKey = Environment.GetEnvironmentVariable("");
			var client = new SendGridClient(apiKey);
			var from = new EmailAddress(model.Email, model.Firstname);
			var subject = model.Subject;
			var to = new EmailAddress("rick.spanjers@outlook.com", "SpanDev");
			var plainTextContent = model.Message;
			var htmlContent = model.Message;
			var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
			var response = await client.SendEmailAsync(msg);
			return RedirectToAction("Index", "Home");
		}


		public IActionResult RetrieveContactForm()
		{
			var model = new MailViewModel();
			return PartialView("Contactform", model);
		}
	}
}