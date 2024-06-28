using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TravarselCoreProje.Areas.Member.Models;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/User")]
    [Authorize(Policy = "AdminPolicy")]
    public class UserController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserService;
        private readonly IRezervationService _rezervationService;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, IAppUserService appUserService, IRezervationService rezervationService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _appUserService = appUserService;
            _rezervationService = rezervationService;
            _signInManager = signInManager;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var usersInAdminRole = await _userManager.GetUsersInRoleAsync("admin");
            return View(usersInAdminRole);
        }

        [HttpGet]
        [Route("MemberList")]
        public async Task<IActionResult> MemberList()
        {
            var usersInAdminRole = await _userManager.GetUsersInRoleAsync("member");
            return View(usersInAdminRole);
        }

        [HttpGet]
        [Route("SearchUsers")]
        public async Task<IActionResult> SearchUsers(string searchString)
        {
            var usersInAdminRole = await _userManager.GetUsersInRoleAsync("member");

            if (!String.IsNullOrEmpty(searchString))
            {
                usersInAdminRole = usersInAdminRole.Where(u => u.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) || u.NamSurname.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return PartialView("_UserTable", usersInAdminRole);
        }

        [HttpPost]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound($"ID'si {id} olan kullanıcı bulunamadı.");
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Default");
            }
            else
            {
                return View();
            }
        }

        [Route("EditUser/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // UserEditModel'e dönüştürme
            var model = new UserEditModel
            {
                name = user.Name,
                surname = user.NamSurname,
                userName = user.UserName,
                mail = user.Email,
                phonenumber = user.PhoneNumber,
                gender = user.Gender
            };

            return View(model);
        }

        [Route("EditUser/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditUser(UserEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.id);
            if (user == null)
            {
                return NotFound();
            }

            // Kullanıcının güncellenecek bilgilerini atama
            user.Name = model.name;
            user.NamSurname = model.surname;
            user.UserName = model.userName;
            user.Email = model.mail;
            user.PhoneNumber = model.phonenumber;
            user.Gender = model.gender;

            // Şifre güncelleme işlemi
            if (!string.IsNullOrEmpty(model.password))
            {
                var passwordValidator = HttpContext.RequestServices.GetService(typeof(IPasswordValidator<AppUser>)) as IPasswordValidator<AppUser>;
                var passwordHasher = HttpContext.RequestServices.GetService(typeof(IPasswordHasher<AppUser>)) as IPasswordHasher<AppUser>;

                var aresult = await passwordValidator.ValidateAsync(_userManager, user, model.password);
                if (aresult.Succeeded)
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, model.password);
                }
                else
                {
                    foreach (var error in aresult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model); // Şifre hatalıysa tekrar view'e gönder
                }
            }

            // Profil resmi güncelleme işlemi
            if (model.imageurl != null)
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
                var extension = Path.GetExtension(model.imageurl.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var imagePathNew = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImages", imageName);
                using (var stream = new FileStream(imagePathNew, FileMode.Create))
                {
                    await model.imageurl.CopyToAsync(stream);
                }
                user.Image = imageName;
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                // Güncelleme başarısız olduysa hata işleme
                ModelState.AddModelError("", "Kullanıcı güncellenirken bir hata oluştu.");
                return View(model);
            }

            // Başarılı ise yönlendirme
            return RedirectToAction("Index"); // veya uygun bir yönlendirme
        }


        [Route("CommentUser/{id}")]
        public IActionResult CommentUser(int id)
        {
            _appUserService.TGetList();
            return View();
        }

        [Route("RezarvationUser/{id}")]
        public IActionResult RezarvationUser(int id)
        {
            var values = _rezervationService.TGetListRezervationByAcceptted(id);
            return View(values);
        }
    }
}
