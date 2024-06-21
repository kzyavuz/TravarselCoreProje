using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.ViewComponents.Default
{
    public class _WhyUS : ViewComponent
    {
        private readonly IAbout2Service _about2Service;

        public _WhyUS(IAbout2Service about2Service)
        {
            _about2Service = about2Service;
        }

        public IViewComponentResult Invoke()
        {
            var values = _about2Service.TGetList();
            return View(values);
        }
    }
}
