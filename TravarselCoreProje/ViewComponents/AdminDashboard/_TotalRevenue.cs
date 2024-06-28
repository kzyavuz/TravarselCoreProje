using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    public class _TotalRevenue : ViewComponent
    {
        private readonly Context _context;

        public _TotalRevenue(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            var totalPrime = _context.Rezarvations.Include(x => x.Destination).Where
                    (x => x.Destination.Status == true && x.Status == "Onaylandı").ToList();

            ViewBag.v3 = totalPrime.Sum(o => o.Destination.Price);

            return View();
        }
    }
}
