using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    [AllowAnonymous]

    public class AboutController : Controller
    {
        private readonly Context _context;

        public AboutController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault();

            // ViewBag'e veriyi ekleme
            ViewBag.aTitle1 = about.Title;
            ViewBag.aTitle2 = about.Title2;
            ViewBag.Des1 = about.Description;
            ViewBag.Des2 = about.Description2;

            return View();
        }
    }
}
