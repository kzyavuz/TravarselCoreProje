using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Contact/")]
    [Authorize(Policy = "AdminPolicy")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _contactService.TGetList();
            return View(values);
        }

        [HttpGet]
        [Route("AddContact")]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        [Route("AddContact")]
        public IActionResult AddContact(Contact contact)
        {
            _contactService.TAdd(contact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("UpdateContact/{id}")]
        public IActionResult UpdateContact(int id)
        {
            var values = _contactService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateContact/{id}")]
        public IActionResult UpdateContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetByID(id);
            _contactService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
