using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    [Route("Contact/")]
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactInfoService _contactInfoService;
        private readonly IMapper _mapper;

        public ContactController(IContactInfoService contactInfoService, IMapper mapper)
        {
            _contactInfoService = contactInfoService;
            _mapper = mapper;
        }

        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Index")]
        [HttpPost]
        public IActionResult Index(MessageDTO model)
        {
            if (ModelState.IsValid)
            {
                _contactInfoService.TAdd(new ContactInfo()
                {
                    MessageBody = model.MessageBody,
                    ContactInfoMail = model.ContactInfoMail,
                    MessageStatus = true,
                    ContactInfoName = model.ContactInfoName,
                    ContactInfoSubject = model.ContactInfoSubject,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
