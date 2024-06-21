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
    public class _Footer : ViewComponent
    {
        private readonly ICatagoryService _catagoryService;

        public _Footer(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _catagoryService.TGetList();
            return View(values);
        }
    }
}
