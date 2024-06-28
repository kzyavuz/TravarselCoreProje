using BusinessLayer.Abstract;
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
    public class DefaultController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly Context _c;

        public DefaultController(IDestinationService destinationService, Context c)
        {
            _destinationService = destinationService;
            _c = c;
        }

        public IActionResult Index()
        {
            var result = _destinationService.TGetList().Where(d => d.Date < DateTime.Now).ToList();
            foreach (var item in result)
            {
                item.Status = false;
                _destinationService.TUpdate(item);
            }


            var rezervations = _c.Rezarvations.Include(x => x.Destination).Where(r => r.Status == "Onay Bekliyor").ToList();
            foreach (var item in rezervations)
            {
                if (!item.Destination.Status)
                {
                    item.Status = "Reddedildi";
                    _c.SaveChanges();
                }
            }

            var rezervation = _c.Rezarvations.Include(x => x.Destination).Where(r => r.Status == "Onaylandı").ToList();
            foreach (var item in rezervation)
            {
                if (!item.Destination.Status)
                {
                    item.Status = "Geçmis Rezervasyon";
                    _c.SaveChanges();
                }
            }
            return View();
        }
    }
}
