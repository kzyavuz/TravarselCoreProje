﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult Header()
        {
            return PartialView();
        }
        public PartialViewResult AppBrandDemo()
        {
            return PartialView();
        }

        public PartialViewResult SideBar()
        {
            return PartialView();
        }
    }
}
