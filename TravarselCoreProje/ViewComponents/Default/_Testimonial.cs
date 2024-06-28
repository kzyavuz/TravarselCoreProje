using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.ViewComponents.Default
{
    public class _Testimonial: ViewComponent
    {
        private readonly ICommnetService _commnetService;

        public _Testimonial(ICommnetService commnetService)
        {
            _commnetService = commnetService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _commnetService.GetListCommentDestination().Where(x=>x.State == true).ToList();
            return View(values);
        }
    }
}
