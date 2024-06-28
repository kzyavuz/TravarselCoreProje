using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.ViewComponents.Default
{
    public class _Slider: ViewComponent
    {
        private readonly Context _context;

        public _Slider(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Destinations.Include(x=> x.Catagory).Where(x=>x.Status == true).ToList();
            return View(values);
        }
    }
}
