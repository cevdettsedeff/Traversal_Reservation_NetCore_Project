using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal_Reservation_NetCore_Project.Models;

namespace Traversal_Reservation_NetCore_Project.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailRequest mailRequest)
        {
            MimeMessage mimemessage = new MimeMessage();
            
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "traversalcore2.gmail.com");
            mimemessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimemessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimemessage.Body = bodyBuilder.ToMessageBody();

            mimemessage.Subject = mailRequest.Subject;

             SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("traversalcore2.gmail.com", "123456aA-");
            client.Send(mimemessage);
            client.Disconnect(true);

            return View();
        }
    }
}
