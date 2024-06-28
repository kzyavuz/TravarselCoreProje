using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravarselCoreProje.Models;

namespace TravarselCoreProje.Controllers
{
    [AllowAnonymous]
    public class ForgetPasswordChange : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ForgetPasswordChange(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(forgetPasswordViewModel.mail);
                if (existingUser == null)
                {
                    ModelState.AddModelError("", "Böyle bir mail adresi sisteme kayıtlı değil.");
                    return View(forgetPasswordViewModel);
                }

                var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.mail);
                string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetTokenLink = Url.Action("ResetPassword", "ForgetPasswordChange", new
                {
                    userId = user.Id,
                    token = passwordResetToken
                }, HttpContext.Request.Scheme);

                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "yavuzkoz222@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.mail);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = passwordResetTokenLink;

                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "Sifre değistirme talebi";

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("yavuzkoz222@gmail.com", "rnsnfhibsewhgdhu");
                client.Send(mimeMessage);
                client.Disconnect(true);
                return View(forgetPasswordViewModel);
            }
            else
            {
                return View(forgetPasswordViewModel);
            }
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
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
                ModelState.AddModelError("", "User ID veya Token bulunamadı.");
                return View(resetPasswordViewModel);
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
