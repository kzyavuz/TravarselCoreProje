using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnonuncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravarselCoreProje.Areas.Admin.Models;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Annoncement/")]
    [Authorize(Policy = "AdminPolicy")]
    public class AnnoncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnoncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());
            return View(values);
        }

        [Route("AddAnnouncement")]
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [Route("AddAnnouncement")]
        [HttpPost]
        public IActionResult AddAnnouncement(AnnonuncementAddDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Annonuncement()
                {
                    Content = model.Content,
                    Title = model.Title,
                    ContentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("UpdateAnnoncement/{id}")]
        [HttpGet]
        public IActionResult UpdateAnnoncement(int id)
        {
            var values = _mapper.Map<AnnonuncementUpdateDTO>(_announcementService.TGetByID(id));
            return View(values);
        }

        [Route("UpdateAnnoncement/{id}")]
        [HttpPost]
        public IActionResult UpdateAnnoncement(AnnonuncementUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Annonuncement
                {
                    AnnonuncementID = model.AnnonuncementID,
                    Title = model.Title,
                    Content = model.Content,
                    ContentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Route("DeleteAnnouncement/{id}")]
        public IActionResult DeleteAnnouncement(int id)
        {
            var result = _announcementService.TGetByID(id);
            _announcementService.TDelete(result);
            return RedirectToAction("Index");
        }
    }
}
