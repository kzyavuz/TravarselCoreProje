using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.ViewComponents.MemberDashboard
{
    public class _Announcements:ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public _Announcements(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _announcementService.TGetList()
                            .OrderByDescending(a => a.ContentDate)
                            .Take(3)
                            .ToList();
            return View(values);
        }
    }
}
