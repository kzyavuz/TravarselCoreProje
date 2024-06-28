using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminRezervationConfirm/")]
    [Authorize(Policy = "AdminPolicy")]
    public class AdminRezervationConfirmController : Controller
    {
        private readonly IRezervationService _rezervationService;
        private readonly Context _c;

        public AdminRezervationConfirmController(IRezervationService rezervationService, Context c)
        {
            _rezervationService = rezervationService;
            _c = c;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _c.Rezarvations.Include(x => x.AppUSer).Include(x=> x.Destination).Where(x => x.Destination.Status == true && x.Status == "Onay Bekliyor").OrderByDescending(x=>x.RezarvationDate).ToList();
            return View(values);
        }
        [Route("AccessRezervation")]
        public IActionResult AccessRezervation()
        {
            var values = _c.Rezarvations.Include(x => x.AppUSer).Include(x => x.Destination).Where(x => x.Destination.Status == true && x.Status == "Onaylandı").OrderByDescending(x => x.RezarvationDate).ToList();
            return View(values);
        }
        [Route("RejectRezervation")]
        public IActionResult RejectRezervation()
        {
            var rezervations = _c.Rezarvations.Include(x => x.AppUSer).Include(x => x.Destination).Where(r => r.Status == "Reddedildi").OrderByDescending(x => x.RezarvationDate).ToList();
            return View(rezervations);
        }

        [Route("PendingRezervation")]
        public IActionResult PendingRezervation()
        {
            var rezervations = _c.Rezarvations.Include(x => x.AppUSer).Include(x => x.Destination).Where(r => r.Status == "Geçmis Rezervasyon").OrderByDescending(x => x.RezarvationDate).ToList();
            return View(rezervations);
        }

        [HttpPost]
        [Route("AccessConfirm/{id}")]
        public IActionResult AccessConfirm(int id)
        {
            _rezervationService.TGetAccessConfirm(id);
            return RedirectToAction("AccessRezervation");
        }

        [HttpPost]
        [Route("RejectConfirm/{id}")]
        public IActionResult RejectConfirm(int id)
        {
            _rezervationService.TGetRejectConfirm(id);
            return RedirectToAction("RejectRezervation");
        }
    }
}
