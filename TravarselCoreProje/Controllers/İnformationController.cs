﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    public class İnformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
