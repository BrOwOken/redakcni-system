using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedakcniSystem.Data.Models;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using RedakcniSystem.Data;

namespace RedakcniSystem.Controllers
{
    public class MailController : Controller
    {
        private ApplicationDbContext _dbContext;
        public MailController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("/test")]
        public IActionResult Email(Article article)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("zahumenskyuwu@gmail.com"));
            string email = string.Empty;
            foreach (var mail in _dbContext.Newsletters)
            {
                message.To.Add(new MailboxAddress(mail.Email));
                email = mail.Email;
            }
            message.Subject = article.Title;

            message.Body = new TextPart("plain")
            {
                Text = article.Content
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("zahumenskyuwu@gmail.com", "");

                client.Send(message);
                client.Disconnect(true);
            }
            return View(new MailModel()
            {
                Email = email,
                Text = article.Content,
                Title = article.Title,
            });

        }
    }
}
