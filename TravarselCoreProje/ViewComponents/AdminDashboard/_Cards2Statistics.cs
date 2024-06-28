
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    public class _Cards2Statistics : ViewComponent
    {
        private readonly Context _context;

        public _Cards2Statistics(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Rezarvations.Include(x => x.Destination).Where
                    (x => x.Destination.Status == true && x.Status == "Onaylandı").Count();

            ViewBag.v2 = _context.Rezarvations.Include(x => x.Destination).Where
                    (x => x.Destination.Status == true && x.Status == "Onay Bekliyor").Count();

            var totalPrime = _context.Rezarvations.Include(x => x.Destination).Where
                    (x => x.Destination.Status == true && x.Status == "Onay Bekliyor").ToList();

            ViewBag.v3 = totalPrime.Sum(o => o.Destination.Price);

            return View();
        }
    }
}
