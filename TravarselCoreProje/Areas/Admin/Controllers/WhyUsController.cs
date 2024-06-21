using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/WhyUs/")]
    public class WhyUsController : Controller
    {
        private readonly IAbout2Service _about2Service;

        public WhyUsController(IAbout2Service about2Service)
        {
            _about2Service = about2Service;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _about2Service.TGetList();
            return View(values);
        }
    }
}
