
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/Message/")]
    [Authorize(Policy = "MemberPolicy")]
    public class MessageController : Controller
    {
        private readonly IContactInfoService _contactInfo;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IContactInfoService contactInfo, UserManager<AppUser> userManager)
        {
            _contactInfo = contactInfo;
            _userManager = userManager;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var List_value = _contactInfo.MyGetListContactInfo(values.Id).Take(5).ToList();
            return View(List_value);
        }
    }
}
