using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using TravarselCoreProje.Areas.Member.Models;

namespace TravarselCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/Profile/")]
    [Authorize(Policy = "MemberPolicy")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (values == null)
            {
                return NotFound();
            }

            UserEditModel userEditModel = new UserEditModel
            {
                name = values.Name,
                surname = values.NamSurname,
                userName = values.UserName,
                phonenumber = values.PhoneNumber,
                mail = values.Email,
                gender = values.Gender
            };
            return View(userEditModel);
        }

        [Route("Index")]
        [HttpPost]
        public async Task<IActionResult> Index(UserEditModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            if (p.imageurl != null)
            {
                // Eski resmi sil
                if (!string.IsNullOrEmpty(user.Image))
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImages", user.Image);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                // Yeni resmi yükle
                var extension = Path.GetExtension(p.imageurl.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var imagePathNew = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImages", imageName);
                using (var stream = new FileStream(imagePathNew, FileMode.Create))
                {
                    await p.imageurl.CopyToAsync(stream);
                }
                user.Image = imageName;
            }

            bool userNameChanged = user.UserName != p.userName;

            user.Name = p.name;
            user.NamSurname = p.surname;
            user.UserName = p.userName;
            user.PhoneNumber = p.phonenumber;
            user.Email = p.mail;
            user.Gender = p.gender;

            if (!string.IsNullOrEmpty(p.password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                if (userNameChanged)
                {
                    // Kullanıcı adının değiştiğini kontrol et ve çıkış yaptır
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("SignIn", "Login");
                }
                return RedirectToAction("MemberDashboard", "Dashboard", new { area = "Member" });
            }

            // Güncelleme başarısız olduğunda hata mesajlarını model durumu ile ilişkilendir
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(p);
        }
    }
}
