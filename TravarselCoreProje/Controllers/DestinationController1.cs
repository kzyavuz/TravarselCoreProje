using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    public class DestinationController1 : Controller
    {
        private Array lines;

        private readonly Context _context;

        public DestinationController1(Context context)
        {
            _context = context;
        }

        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        public Array DestinationsSplit(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                this.lines = data.Split("*");
            }
            return lines;
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            ViewBag.i = id;
            var values = destinationManager.TGetByID(id);


            //string[] fields = new string[4];
            //string[] des = new string[5];

            //for (var i = 0; i < 5; i++)
            //{
            //    string detailsFieldName = "Details" + (i + 1); // Dinamik olarak alan adını oluştur

            //    fields[i] = _context.Destinations.Select(e => EF.Property<string>(e, detailsFieldName)).FirstOrDefault();

            //    ViewBag.write[i] = destinationsSplit(fields[i]);
            //}

            var data = _context.Destinations.Where(e => e.DestinationID == id).Select(e => e.Details1).FirstOrDefault();
            ViewBag.des1 = DestinationsSplit(data);
            
            data = _context.Destinations.Where(e => e.DestinationID == id).Select(e => e.Details2).FirstOrDefault();
            ViewBag.des2 = DestinationsSplit(data);

            data = _context.Destinations.Where(e => e.DestinationID == id).Select(e => e.Details3).FirstOrDefault();
            ViewBag.des3 = DestinationsSplit(data);

            data = _context.Destinations.Where(e => e.DestinationID == id).Select(e => e.Details4).FirstOrDefault();
            ViewBag.des4 = DestinationsSplit(data);

            data = _context.Destinations.Where(e => e.DestinationID == id).Select(e => e.Details5).FirstOrDefault();
            ViewBag.des5 = DestinationsSplit(data);

            return View(values);
        }

        [HttpPost]
        public IActionResult DestinationDetails(Destination d)
        {
            return View();
        }
    }
}
