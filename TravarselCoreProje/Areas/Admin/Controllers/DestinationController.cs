using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Destination/")]

    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        [Route("AddDestinations")]
        [HttpGet]
        public IActionResult AddDestinations()
        {
            return View();
        }

        [Route("AddDestinations")]
        [HttpPost]
        public IActionResult AddDestinations(Destination destination)
        {
            _destinationService.TAdd(destination);
            return RedirectToAction("Index");
        }


        [Route("DeleteDestinations/{id}")]
        public IActionResult DeleteDestinations(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return RedirectToAction("Index");
        }

        [Route("UpdateDestinations/{id}")]
        [HttpGet]
        public IActionResult UpdateDestinations(int id)
        {
            var values = _destinationService.TGetByID(id);
            return View(values);
        }

        [Route("UpdateDestinations/{id}")]
        [HttpPost]
        public IActionResult UpdateDestinations(Destination destination)
        {
            _destinationService.TUpdate(destination);
            return RedirectToAction("Index");
        }
    }
}
