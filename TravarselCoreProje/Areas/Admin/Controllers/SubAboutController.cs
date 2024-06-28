using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SubAbout/")]
    [Authorize(Policy = "AdminPolicy")]
    public class SubAboutController : Controller
    {
        private readonly ISubAboutService _subAboutService;

        public SubAboutController(ISubAboutService subAboutService)
        {
            _subAboutService = subAboutService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _subAboutService.TGetList();
            return View(values);
        }

        [HttpGet]
        [Route("AddSubAbout")]
        public IActionResult AddSubAbout()
        {
            return View();
        }

        [HttpPost]
        [Route("AddSubAbout")]
        public IActionResult AddSubAbout(SubAbout subAbout)
        {
            _subAboutService.TAdd(subAbout);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("UpdateSubAbout/{id}")]
        public IActionResult UpdateSubAbout(int id)
        {
            var values = _subAboutService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateSubAbout/{id}")]
        public IActionResult UpdateSubAbout(SubAbout subAbout)
        {
            _subAboutService.TUpdate(subAbout);
            return RedirectToAction("Index");
        }

        [Route("DeleteSubAbout/{id}")]
        public IActionResult DeleteSubAbout(int id)
        {
            var values = _subAboutService.TGetByID(id);
            _subAboutService.TDelete(values);
            return RedirectToAction("Index");
        }

    }
}
