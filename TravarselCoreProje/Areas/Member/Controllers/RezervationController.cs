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
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());
        RezervationManager rezervationManager = new RezervationManager(new EFRezervationDal());

        private readonly UserManager<AppUser> _userManager;

        public RezervationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MyActiveRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var List_value = rezervationManager.GetListRzervationByAcceptted(values.Id);
            return View(List_value);
        }

        public async Task<IActionResult> MyPastRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var List_value = rezervationManager.GetListRzervationByPast(values.Id);
            return View(List_value);
        }

        public async Task<IActionResult> MyPendingApprovalRezervation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var List_value = rezervationManager.GetListRzervationByPendingReservations(values.Id);
            return View(List_value);
        }

        [HttpGet]
        public IActionResult NewRezervation()
        {
            List<SelectListItem> values = (from item in destinationManager.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = item.City,
                                              Value = item.DestinationID.ToString()
                                          }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult NewRezervation(Rezarvation p)
        {
            p.AppUSerID = 6;
            p.Status = "Onay Bekliyor";
            rezervationManager.TAdd(p);
            return RedirectToAction("MyActiveRezervation");
        }
    }
}
