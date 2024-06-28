using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/Dashboard")]
    [Authorize(Policy = "MemberPolicy")]
    public class DashboardController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICommnetService _commnetService;
        private readonly IContactInfoService _contactInfoService;
        private readonly IRezervationService _rezervationService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(SignInManager<AppUser> signInManager, ICommnetService commnetService, IContactInfoService contactInfoService, IRezervationService rezervationService, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _commnetService = commnetService;
            _contactInfoService = contactInfoService;
            _rezervationService = rezervationService;
            _userManager = userManager;
        }

        [Route("MemberDashboard")]
        public async Task<IActionResult> MemberDashboard()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.comment = _commnetService.TMyGetListCommentCount(values.Id);
            ViewBag.message = _contactInfoService.TMyGetListContactCount(values.Id);
            ViewBag.destination = _rezervationService.TMyGetRezervationCount(values.Id);
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
