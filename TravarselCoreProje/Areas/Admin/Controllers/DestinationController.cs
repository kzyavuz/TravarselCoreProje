using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TravarselCoreProje.Areas.Admin.Models;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Destination/")]
    [Authorize(Policy = "AdminPolicy")]
    public class DestinationController : Controller
    {
        private readonly ICatagoryService _catagoryService; // Kategori servisi
        private readonly IGuideService _guideService; // Rehber servisi
        private readonly IDestinationService _destinationService; // Etkinlik servisi

        public DestinationController(ICatagoryService catagoryService, IGuideService guideService, IDestinationService destinationService)
        {
            _catagoryService = catagoryService;
            _guideService = guideService;
            _destinationService = destinationService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _destinationService.TGetList().OrderByDescending(x => x.Date).ToList();
            return View(values);
        }

        [Route("AddDestinations")]
        [HttpGet]
        public IActionResult AddDestinations()
        {
            var categories = _catagoryService.TGetList().Where(x => x.Status == true).Select(item => new SelectListItem
            {
                Text = item.CatagoryName,
                Value = item.CatagoryID.ToString()
            }).ToList();
            ViewBag.c = categories;

            var guides = _guideService.TGetList().Where(x => x.Status == true).Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.GuideID.ToString()
            }).ToList();
            ViewBag.g = guides;

            return View();
        }

        [Route("AddDestinations")]
        [HttpPost]
        public IActionResult AddDestinations(DestinationViewModel p)
        {
            if (!ModelState.IsValid)
            {
                // ViewBag verilerini yeniden ayarlayın
                ViewBag.c = _catagoryService.TGetList().Where(x => x.Status == true).Select(item => new SelectListItem
                {
                    Text = item.CatagoryName,
                    Value = item.CatagoryID.ToString()
                }).ToList();

                ViewBag.g = _guideService.TGetList().Where(x => x.Status == true).Select(item => new SelectListItem
                {
                    Text = item.Name,
                    Value = item.GuideID.ToString()
                }).ToList();

                return View(p);
            }

            var s = new Destination
            {
                DestinationName = p.DestinationName,
                City = p.City,
                DayNight = p.DayNight,
                Price = p.Price,
                District = p.District,
                Description = p.Description,
                Capacity = p.Capacity,
                Content = p.Content,
                Status = true,
                CatagoryID = p.CatagoryID,
                GuideID = p.GuideID,
                Date = p.Date
            };

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

            try
            {
                _destinationService.TAdd(s);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Etkinlik eklenirken bir hata oluştu: " + ex.Message);

                // ViewBag verilerini yeniden ayarlayın
                ViewBag.c = _catagoryService.TGetList().Where(x => x.Status == true).Select(item => new SelectListItem
                {
                    Text = item.CatagoryName,
                    Value = item.CatagoryID.ToString()
                }).ToList();

                ViewBag.g = _guideService.TGetList().Where(x => x.Status == true).Select(item => new SelectListItem
                {
                    Text = item.Name,
                    Value = item.GuideID.ToString()
                }).ToList();

                return View(p);
            }
        }

        [HttpPost]
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
                CatagoryID = destination.CatagoryID,
                GuideID = destination.GuideID,
                Status = true,
                Date = destination.Date,
                Content = destination.Content,
                ImageUrl = destination.Image,
                Image1Url = destination.Image1,
                Image2Url = destination.Image2
            };

            var categories = _catagoryService.TGetList().Where(x => x.Status == true).Select(item => new SelectListItem
            {
                Text = item.CatagoryName,
                Value = item.CatagoryID.ToString()
            }).ToList();
            ViewBag.c = categories;

            var guides = _guideService.TGetList().Where(x => x.Status == true).Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.GuideID.ToString()
            }).ToList();
            ViewBag.g = guides;

            return View(model);
        }

        [Route("UpdateDestinations/{id}")]
        [HttpPost]
        public IActionResult UpdateDestinations(DestinationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // ViewBag verilerini yeniden ayarlayın
                ViewBag.c = _catagoryService.TGetList().Where(x => x.Status == true).Select(item => new SelectListItem
                {
                    Text = item.CatagoryName,
                    Value = item.CatagoryID.ToString()
                }).ToList();

                ViewBag.g = _guideService.TGetList().Where(x => x.Status == true).Select(item => new SelectListItem
                {
                    Text = item.Name,
                    Value = item.GuideID.ToString()
                }).ToList();

                return View(model);
            }

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
            destination.CatagoryID = model.CatagoryID;
            destination.GuideID = model.GuideID;
            destination.Capacity = model.Capacity;
            destination.Content = model.Content;
            destination.Date = model.Date;

            if (model.NewImageFile != null)
            {
                if (!string.IsNullOrEmpty(destination.Image))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", destination.Image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                var extension = Path.GetExtension(model.NewImageFile.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", newImageName);

                using (var stream = new FileStream(newImagePath, FileMode.Create))
                {
                    model.NewImageFile.CopyTo(stream);
                }

                destination.Image = newImageName;
            }

            if (model.NewImage1File != null)
            {
                if (!string.IsNullOrEmpty(destination.Image1))
                {
                    var oldImagePath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", destination.Image1);
                    if (System.IO.File.Exists(oldImagePath1))
                    {
                        System.IO.File.Delete(oldImagePath1);
                    }
                }

                var extension1 = Path.GetExtension(model.NewImage1File.FileName);
                var newImageName1 = Guid.NewGuid() + extension1;
                var newImagePath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", newImageName1);

                using (var stream = new FileStream(newImagePath1, FileMode.Create))
                {
                    model.NewImage1File.CopyTo(stream);
                }

                destination.Image1 = newImageName1;
            }

            if (model.NewImage2File != null)
            {
                if (!string.IsNullOrEmpty(destination.Image2))
                {
                    var oldImagePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", destination.Image2);
                    if (System.IO.File.Exists(oldImagePath2))
                    {
                        System.IO.File.Delete(oldImagePath2);
                    }
                }

                var extension2 = Path.GetExtension(model.NewImage2File.FileName);
                var newImageName2 = Guid.NewGuid() + extension2;
                var newImagePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageDestination/", newImageName2);

                using (var stream = new FileStream(newImagePath2, FileMode.Create))
                {
                    model.NewImage2File.CopyTo(stream);
                }

                destination.Image2 = newImageName2;
            }

            _destinationService.TUpdate(destination);
            return RedirectToAction("Index");
        }
    }
}
