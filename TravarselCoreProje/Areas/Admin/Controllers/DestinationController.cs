using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TravarselCoreProje.Areas.Admin.Models;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Destination/")]

    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _destinationService.TGetList().OrderBy(x => x.Date).ToList();
            return View(values);
        }

        [Route("AddDestinations")]
        [HttpGet]
        public IActionResult AddDestinations()
        {
            return View();
        }

        [Route("AddDestinations")]
        [HttpPost]
        public IActionResult AddDestinations(DestinationViewModel p, Destination s)
        {
            if (!ModelState.IsValid)
            {
                // Model doğrulaması başarısız
                return View(p);
            }

            var now = DateTime.Now;

            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", newImageName);

                using (var stream = new FileStream(location, FileMode.Create))
                {
                    p.Image.CopyTo(stream);
                }

                s.Image = newImageName;
            }

            if (p.Image1 != null)
            {
                var extension1 = Path.GetExtension(p.Image1.FileName);
                var newImageName1 = Guid.NewGuid() + extension1;
                var location1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", newImageName1);

                using (var stream = new FileStream(location1, FileMode.Create))
                {
                    p.Image1.CopyTo(stream);
                }

                s.Image1 = newImageName1;
            }

            if (p.Image2 != null)
            {
                var extension2 = Path.GetExtension(p.Image2.FileName);
                var newImageName2 = Guid.NewGuid() + extension2;
                var location2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", newImageName2);

                using (var stream = new FileStream(location2, FileMode.Create))
                {
                    p.Image2.CopyTo(stream);
                }

                s.Image2 = newImageName2;
            }

            s.DestinationName = p.DestinationName;
            s.City = p.City;
            s.DayNight = p.DayNight;
            s.Price = p.Price;
            s.District = p.District;
            s.Description = p.Description;
            s.Capacity = p.Capacity;
            s.Content = p.Content;
            s.Status = true;
            s.CatagoryID = 12;
            s.GuideID = 2;
            s.Date = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);

            try
            {
                _destinationService.TAdd(s);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Etkinlik eklenirken bir hata oluştu: " + ex.Message);
            }

            return View(p);
        }


        [Route("DeleteDestinations/{id}")]
        public IActionResult DeleteDestinations(int id)
        {
            var destination = _destinationService.TGetByID(id);
            if (destination == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(destination.Image))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", destination.Image);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            if (!string.IsNullOrEmpty(destination.Image1))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", destination.Image1);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            if (!string.IsNullOrEmpty(destination.Image2))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", destination.Image2);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _destinationService.TDelete(destination);
            return RedirectToAction("Index");
        }

        [Route("UpdateDestinations/{id}")]
        [HttpGet]
        public IActionResult UpdateDestinations(int id)
        {
            var destination = _destinationService.TGetByID(id);
            if (destination == null)
            {
                return NotFound();
            }

            var model = new DestinationViewModel
            {
                DestinationID = destination.DestinationID,
                DestinationName = destination.DestinationName,
                City = destination.City,
                DayNight = destination.DayNight,
                Price = destination.Price,
                District = destination.District,
                Description = destination.Description,
                Capacity = destination.Capacity,
                Content = destination.Content,
                ImageUrl = destination.Image,
                Image1Url = destination.Image1,
                Image2Url = destination.Image2
            };

            return View(model);
        }

        [Route("UpdateDestinations/{id}")]
        [HttpPost]
        public IActionResult UpdateDestinations(DestinationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var destination = _destinationService.TGetByID(model.DestinationID);
                if (destination == null)
                {
                    return NotFound();
                }

                destination.DestinationName = model.DestinationName;
                destination.City = model.City;
                destination.DayNight = model.DayNight;
                destination.Price = model.Price;
                destination.District = model.District;
                destination.Description = model.Description;
                destination.Capacity = model.Capacity;
                destination.Content = model.Content;

                if (model.NewImageFile != null)
                {
                    // Eski resim dosyasını sil
                    if (!string.IsNullOrEmpty(destination.Image))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", destination.Image);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Yeni resim dosyasını yükle
                    var extension = Path.GetExtension(model.NewImageFile.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", newImageName);
                    using (var stream = new FileStream(newImagePath, FileMode.Create))
                    {
                        model.NewImageFile.CopyTo(stream);
                    }

                    // Yeni resim dosyası bilgisi güncellenir
                    destination.Image = newImageName;
                }
                

                if (model.NewImage1File != null)
                {
                    // Eski resim dosyasını sil
                    if (!string.IsNullOrEmpty(destination.Image1))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", destination.Image1);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Yeni resim dosyasını yükle
                    var extension1 = Path.GetExtension(model.NewImage1File.FileName);
                    var newImageName1 = Guid.NewGuid() + extension1;
                    var newImagePath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", newImageName1);
                    using (var stream = new FileStream(newImagePath1, FileMode.Create))
                    {
                        model.NewImageFile.CopyTo(stream);
                    }

                    // Yeni resim dosyası bilgisi güncellenir
                    destination.Image1 = newImageName1;
                }
                

                if (model.NewImage2File != null)
                {
                    // Eski resim dosyasını sil
                    if (!string.IsNullOrEmpty(destination.Image2))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", destination.Image2);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Yeni resim dosyasını yükle
                    var extension2 = Path.GetExtension(model.NewImage2File.FileName);
                    var newImageName2 = Guid.NewGuid() + extension2;
                    var newImagePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", newImageName2);
                    using (var stream = new FileStream(newImagePath2, FileMode.Create))
                    {
                        model.NewImage2File.CopyTo(stream);
                    }

                    // Yeni resim dosyası bilgisi güncellenir
                    destination.Image2 = newImageName2;
                }

                _destinationService.TUpdate(destination);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
