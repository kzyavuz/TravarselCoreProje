using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/Rezervation/")]
    [Authorize(Policy = "MemberPolicy")]
    public class RezervationController : Controller
    {
        private IDestinationService _destinationService;
        private IRezervationService _rezervationService;
        private readonly UserManager<AppUser> _userManager;

        public RezervationController(IDestinationService destinationService, IRezervationService rezervationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _rezervationService = rezervationService;
            _userManager = userManager;
        }

        [Route("MyActiveRezervation")]
        public async Task<IActionResult> MyActiveRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var List_value = _rezervationService.TGetListRezervationByAcceptted(values.Id);
            return View(List_value);
        }

        [Route("RejectRezervation")]
        public async Task<IActionResult> RejectRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var List_value = _rezervationService.TGetListRezervationReject(values.Id);
            return View(List_value);
        }

        [Route("MyPastRezervation")]
        public async Task<IActionResult> MyPastRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var List_value = _rezervationService.TGetListRezervationByPast(values.Id);
            return View(List_value);
        }

        [Route("MyPendingApprovalRezervation")]
        public async Task<IActionResult> MyPendingApprovalRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var List_value = _rezervationService.TGetListRezervationByPendingReservations(values.Id);
            return View(List_value);
        }

        [Route("NewRezervation")]
        [HttpGet]
        public IActionResult NewRezervation()
        {
            List<SelectListItem> values = _destinationService.TGetList().Where(x => x.Status == true).Select(item => new SelectListItem
            {
                Text = item.DestinationName,
                Value = item.DestinationID.ToString()
            }).ToList();

            ViewBag.v = values;
            return View();
        }

        [Route("NewRezervation")]
        [HttpPost]
        public async Task<IActionResult> NewRezervation(Rezarvation p)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> values = _destinationService.TGetList().Where(x => x.Status == true).Select(item => new SelectListItem
                {
                    Text = item.DestinationName,
                    Value = item.DestinationID.ToString()
                }).ToList();
                ViewBag.v = values;
                return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                p.AppUserID = currentUser.Id;
                p.Status = "Onay Bekliyor";
                p.RezarvationDate = DateTime.Now;

                _rezervationService.TAdd(p);

                return Json(new { success = true });
            }

            return Json(new { success = false, errors = new[] { "User not found" } });
        }
    }
}
