using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    public class ErrorePageController : Controller
    {
        public IActionResult Errore404(int code)
        {
            return View();
        }
    }
}
