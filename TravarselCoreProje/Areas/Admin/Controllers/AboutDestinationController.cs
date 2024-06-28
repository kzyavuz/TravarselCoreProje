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
    [Route("Admin/AboutDestination/")]
    [Authorize(Policy = "AdminPolicy")]
    public class AboutDestinationController : Controller
    {
        private readonly IFeatureService _featureService;

        public AboutDestinationController(IFeatureService featureService)
        {
            _featureService = featureService;
        }


        [Route("Index")]
        public IActionResult Index()
        {
            var values = _featureService.TGetList();
            return View(values);
        }

        [Route("Add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add(Feature feature)
        {
            if (ModelState.IsValid)
            {
                _featureService.TAdd(feature);
                return RedirectToAction("Index");
            }
            else
            {
                return View(feature);
            }
        }

        [Route("Update/{id}")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = _featureService.TGetByID(id);
            return View(values);
        }

        [Route("Update/{id}")]
        [HttpPost]
        public IActionResult Update(Feature feature)
        {
            if (ModelState.IsValid)
            {
                _featureService.TUpdate(feature);
                return RedirectToAction("Index");
            }
            else
            {
                return View(feature);
            }
        }

        [Route("Delete/{id}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var values = _featureService.TGetByID(id);
            _featureService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
