using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic : ViewComponent
    {
        private readonly Context _context;

        public _Cards1Statistic(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Destinations.Where(x=> x.Status == true).Count();
            ViewBag.v2 = _context.Destinations.Where(x=> x.Status == false).Count();
            return View();
        }
    }
}
