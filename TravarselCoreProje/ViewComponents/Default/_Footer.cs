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
        CatagoryManager _catagoryManager = new CatagoryManager(new EFCatagoryDal());

        public IViewComponentResult Invoke()
        {
            var data = _catagoryManager.TGetList();
            return View (data);
        }
    }
}
