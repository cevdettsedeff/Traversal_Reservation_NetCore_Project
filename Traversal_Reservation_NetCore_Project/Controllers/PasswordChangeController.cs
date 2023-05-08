using AutoMapper.Internal;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;
using Traversal_Reservation_NetCore_Project.Models;

namespace Traversal_Reservation_NetCore_Project.Controllers
{
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPassword)
        {
            var user = await _userManager.FindByEmailAsync(forgetPassword.Mail);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passwordResetToken,
            }, HttpContext.Request.Scheme);

            MimeMessage mimemessage = new();

            MailboxAddress mailboxAddressFrom = new("Admin", "traversalcore2.gmail.com");
            mimemessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new("User",forgetPassword.Mail);
            mimemessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimemessage.Body = bodyBuilder.ToMessageBody();

            mimemessage.Subject = "Şifre Değişiklik Talebi";

            SmtpClient client = new();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("traversalcore2.gmail.com", "wbertygfdsazx");
            client.Send(mimemessage);
            client.Disconnect(true);
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userid"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];
            if (userid == null || token == null)
            {
                //hata mesajlarını yazabiliriz.
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
