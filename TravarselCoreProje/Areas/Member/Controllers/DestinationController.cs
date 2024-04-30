using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Member.Controllers
{
    public class DestinationController : Controller
    {
        [AllowAnonymous]
        [Area("Member")]
        public IActionResult Index()
        {
            DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());
            var values = destinationManager.TGetList();
            return View(values);
        }
    }
}
