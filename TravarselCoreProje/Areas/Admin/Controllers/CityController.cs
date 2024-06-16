﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravarselCoreProje.Models;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {   
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCity([FromBody] Destination p)
        {
            if (p == null)
            {
                return Json(new { success = false, message = "Geçersiz veri." });
            }

            p.Status = true;
            _destinationService.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(new { success = true, data = values });
        }

        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            if (values == null)
            {
                return Json(new { success = false, message = "Bu ID bulunamadı" });
            }
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(new { success = true, data = jsonValues });
        }

        [HttpPost]
        public IActionResult DeleteCity(int DestinationID)
        {
            var destination = _destinationService.TGetByID(DestinationID);
            if (destination == null)
            {
                return Json(new { success = false, message = "Bu ID bulunamadı" });
            }

            _destinationService.TDelete(destination);
            return Json(new { success = true, message = "Şehir başarılı bir şekilde silindi." });
        }

        [HttpPost]
        public IActionResult UpdateCity([FromBody] Destination p)
        {
            if (p == null || p.DestinationID <= 0)
            {
                return Json(new { success = false, message = "Geçersiz veri." });
            }

            var destination = _destinationService.TGetByID(p.DestinationID);
            if (destination == null)
            {
                return Json(new { success = false, message = "Bu ID bulunamadı" });
            }

            destination.City = p.City;
            destination.DayNight = p.DayNight;
            destination.Price = p.Price;
            destination.Capacity = p.Capacity;

            _destinationService.TUpdate(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(new { success = true, data = values });
        }
    }
}
