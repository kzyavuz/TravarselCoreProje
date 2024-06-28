using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.ViewComponents.AdminDashboard
{
    public class _AdminNavbar:ViewComponent
    {

        private readonly UserManager<AppUser> _userManager;

        public _AdminNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.name = values.Name + " " + values.NamSurname;

            ViewBag.userName = values.UserName;

            ViewBag.image = string.IsNullOrEmpty(values.Image)
                ? Url.Content("~/UserImages/default-profile.jpg")
                : Url.Content($"~/UserImages/{values.Image}");

            return View();
        }
    }
}
