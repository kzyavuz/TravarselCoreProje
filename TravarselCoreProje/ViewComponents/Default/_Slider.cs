using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.ViewComponents.Default
{
    public class _Slider: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
