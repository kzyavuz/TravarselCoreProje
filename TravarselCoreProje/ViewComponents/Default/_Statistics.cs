using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.ViewComponents.Default
{
    public class _Statistics : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _Statistics(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.aetkinlik = _destinationService.TMyGetDestinationCount(true);
            ViewBag.tetkinlik = c.Destinations.Count();
            ViewBag.rehber = c.Guides.Count();
            ViewBag.katagori = c.Catagories.Count();
            return View();
        }
    }
}
