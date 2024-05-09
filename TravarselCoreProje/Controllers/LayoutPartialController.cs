using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    public class LayoutPartialController : Controller
    {
        CatagoryManager _catagoryManager = new CatagoryManager(new EFCatagoryDal());

        public LayoutPartialController(CatagoryManager catagoryManager)
        {
            _catagoryManager = catagoryManager;
        }

        public PartialViewResult Navbar()
        {
            var values = _catagoryManager.TGetList();
            return PartialView(values);
        }

        public PartialViewResult Footer()
        {
            var values = _catagoryManager.TGetList();
            return PartialView(values);
        }
    }
}
