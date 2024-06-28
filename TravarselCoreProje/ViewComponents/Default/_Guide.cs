using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.ViewComponents.Default
{
    public class _Guide : ViewComponent
    {
        private readonly IGuideService _guideService;

        public _Guide(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _guideService.TGetList().Where(x=> x.Status == true && x.StandOut == true).ToList();
            return View(values);
        }
    }
}
