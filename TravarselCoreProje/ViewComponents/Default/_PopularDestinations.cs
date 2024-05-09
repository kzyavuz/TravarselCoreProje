using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.ViewComponents.Default
{
    public class _PopularDestinations: ViewComponent
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = destinationManager.TGetList()
            .Where(e => e.Status == true)
                .OrderBy(e => e.Date)
                .Take(6)
                .ToList();
            return View(values);    
        }
    }
}
