using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    [Route("Contact/")]
    public class ContactController : Controller
    {
        private readonly IContactInfoService _contactInfoService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IContactService _contactService;
        private readonly Context _context;

        public ContactController(IContactInfoService contactInfoService, UserManager<AppUser> userManager, IContactService contactService, Context context)
        {
            _contactInfoService = contactInfoService;
            _userManager = userManager;
            _contactService = contactService;
            _context = context;
        }

        [AllowAnonymous]
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.i = _contactService.TGetList();
            return View();
        }

        [Route("Index")]
        [HttpPost]
        public async Task<IActionResult> Index(MessageDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                _contactInfoService.TAdd(new ContactInfo()
                {
                    MessageBody = model.MessageBody,
                    ContactInfoMail = user.Email, // Kullanıcının email bilgisi
                    MessageStatus = true,
                    ContactInfoName = user.Name, // Kullanıcının isim bilgisi
                    ContactInfoSubject = model.ContactInfoSubject,
                    MessageDate = DateTime.Now,
                    AppUserID = user.Id
                });
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
