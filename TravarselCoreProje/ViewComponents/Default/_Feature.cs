using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.ViewComponents.Default
{
    public class _Feature:ViewComponent
    {
        CatagoryManager catagoryManager = new CatagoryManager(new EFCatagoryDal());
        public IViewComponentResult Invoke()
        {
            var values = catagoryManager.TGetList();
            return View(values);
        }
    }
}
