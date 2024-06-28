using DataAccessLayer.Concrete;
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
    public class BlogController : Controller
    {

        private readonly Context _context;

        public BlogController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // İlk 8 blogu çekiyoruz
            var values = _context.Blogs.Include(x => x.AppUser).OrderByDescending(x => x.Created).Take(8).ToList();
            ViewBag.TotalBlogs = _context.Blogs.Count(); // Toplam blog sayısını ViewBag'e koyuyoruz
            return View(values);
        }

        public IActionResult Post(int id)
        {
            var blog = _context.Blogs.Include(x => x.AppUser).FirstOrDefault(x => x.BlogId == id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [HttpGet]
        public IActionResult GetMoreBlogs(int page)
        {
            int pageSize = 8;
            var ilanlar = _context.Blogs.Include(x => x.AppUser)
                                      .Skip(page * pageSize)
                                      .Take(pageSize)
                                      .ToList();

            return PartialView("_BlogPartial", ilanlar);
        }
    }
}
