using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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

        public async Task<IActionResult> MyActiveRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var List_value = _rezervationService.GetListRzervationByAcceptted(values.Id);
            return View(List_value);
        }

        public async Task<IActionResult> MyPastRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var List_value = _rezervationService.GetListRzervationByPast(values.Id);
            return View(List_value);
        }

        public async Task<IActionResult> MyPendingApprovalRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var List_value = _rezervationService.GetListRzervationByPendingReservations(values.Id);
            return View(List_value);
        }

        [HttpGet]
        public IActionResult NewRezervation()
        {
            List<SelectListItem> values = (from item in _destinationService.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = item.City,
                                              Value = item.DestinationID.ToString()
                                          }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewRezervation(Rezarvation p)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                p.AppUserID = currentUser.Id;
                p.Status = "Onay Bekliyor";
                _rezervationService.TAdd(p);
                return RedirectToAction("/Member/Rezervation/MyActiveRezervation");
            }
            return View();
        }
    }
}
