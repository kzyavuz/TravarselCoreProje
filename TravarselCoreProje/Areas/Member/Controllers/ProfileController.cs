using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TravarselCoreProje.Areas.Member.Models;

namespace TravarselCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditModel userEditModel = new UserEditModel();
            userEditModel.name = values.Name;
            userEditModel.surname = values.NamSurname;
            userEditModel.phonenumber = values.PhoneNumber;
            userEditModel.mail = values.Email;
            return View(userEditModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if(p.imageurl != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.imageurl.FileName);
                var imageName = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/UserImages/" + imageName;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.imageurl.CopyToAsync(stream);
                user.Image = imageName;
            }
            user.Name = p.name;
            user.NamSurname = p.surname;
            user.PhoneNumber = p.phonenumber;
            user.Email = p.mail;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("MemberDashboard", "Dashboard", new { area = "Member" });
            }
            return View();
        }

    }
}
