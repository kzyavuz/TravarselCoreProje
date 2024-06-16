using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    [AllowAnonymous]
    public class DestinationController1 : Controller
    {
        private Array lines;

        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());

        public IActionResult Index(/*int id*/)
        {
            var data = destinationManager.TGetList()/*.Where(e => e.Catagory.CatagoryID == id && e.Catagory.CatagoryID != 0)*/;
            return View(data);
        }

        public Array DestinationsSplit(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                lines = data.Split("*");
                return lines;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            ViewBag.i = id;
            var values = destinationManager.TGetByID(id);

            var data = destinationManager.TGetList().Where(e => e.DestinationID == id).Select(e => e.Details1).FirstOrDefault();
            ViewBag.des1 = DestinationsSplit(data);
            
            data = destinationManager.TGetList().Where(e => e.DestinationID == id).Select(e => e.Details2).FirstOrDefault();
            ViewBag.des2 = DestinationsSplit(data);

            data = destinationManager.TGetList().Where(e => e.DestinationID == id).Select(e => e.Details3).FirstOrDefault();
            ViewBag.des3 = DestinationsSplit(data);

            data = destinationManager.TGetList().Where(e => e.DestinationID == id).Select(e => e.Details4).FirstOrDefault();
            ViewBag.des4 = DestinationsSplit(data);

            return View(values);
        }

        [HttpPost]
        public IActionResult DestinationDetails(Destination d)
        {
            return View();
        }
    }
}
