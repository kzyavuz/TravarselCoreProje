using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());

        [Area("Admin")]

        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestinations()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestinations(Destination destination)
        {
            destinationManager.TAdd(destination);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestinations(int id)
        {
            var values = destinationManager.TGetByID(id);
            destinationManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestinations(int id)
        {
            var values = destinationManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateDestinations(Destination destination)
        {
            destinationManager.TUpdate(destination);
            return RedirectToAction("Index");
        }

    }
}
