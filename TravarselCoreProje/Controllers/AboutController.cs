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
        public IActionResult Index()
        {
            return View();
        }
    }
}
