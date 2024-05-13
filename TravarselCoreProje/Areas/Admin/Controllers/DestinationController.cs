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

    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());

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
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }

        public IActionResult DeleteDestinations(int id)
        {
            var values = destinationManager.TGetByID(id);
            destinationManager.TDelete(values);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
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
            return RedirectToAction("Admin","Destination","Index");
        }
    }
}
