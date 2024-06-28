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
    [Route("Admin/About/")]
    [Authorize(Policy = "AdminPolicy")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _aboutService.TGetList();
            return View(values);
        }

        [Route("AddAbout")]
        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [Route("AddAbout")]
        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            _aboutService.TAdd(about);
            return RedirectToAction("Index");
        }

        [Route("UpdateAbout/{id}")]
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            return View(values);
        }

        [Route("UpdateAbout/{id}")]
        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            _aboutService.TUpdate(about);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("DeleteAbout/{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            _aboutService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
