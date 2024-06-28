using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Dashboard/")]
    [Authorize(Policy = "AdminPolicy")]
    public class DashboardController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public DashboardController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Logout")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default", new { area = "" }); // varsayılan alanına yönlendirme
        }
    }
}
