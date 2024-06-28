using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
    [Area("Admin")]
    [Route("Admin/WhyUs/")]
    [Authorize(Policy = "AdminPolicy")]
    public class WhyUsController : Controller
    {
        private readonly IAbout2Service _about2Service;

        public WhyUsController(IAbout2Service about2Service)
        {
            _about2Service = about2Service;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _about2Service.TGetList();
            return View(values);
        }

        [Route("AddWhyUs")]
        [HttpGet]
        public IActionResult AddWhyUs()
        {
            return View();
        }

        [Route("AddWhyUs")]
        [HttpPost]
        public IActionResult AddWhyUs(WhyUsViewModel p, About2 s)
        {
            WhyUsValidator validationRules = new WhyUsValidator();
            ValidationResult result = validationRules.Validate(s);
            if (result.IsValid)
            {
                if (p.Image != null)
                {
                    var extension = Path.GetExtension(p.Image.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageWhyUs/", newimagename);
                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        p.Image.CopyTo(stream);
                    }
                    s.Image = newimagename;
                }
                s.Title1 = p.Title1;
                s.Title2 = p.Title2;
                s.Description = p.Description;

                try
                {
                    _about2Service.TAdd(s);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Alan eklenirken bir hata oluştu.");
                }
                return View(p);
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [Route("UpdateWhyUs/{id}")]
        [HttpGet]
        public IActionResult UpdateWhyUs(int id)
        {
            var service = _about2Service.TGetByID(id);
            if (service == null)
            {
                return NotFound();
            }

            var model = new WhyUsViewModel
            {
                About2ID = service.About2ID,
                Title1 = service.Title1,
                Title2 = service.Title2,
                Description = service.Description,
                ExistingImagePath = service.Image // Mevcut resim dosyası yolunu sakla
            };
            return View(model);
        }

        [Route("UpdateWhyUs/{id}")]
        [HttpPost]
        public IActionResult UpdateWhyUs(WhyUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = _about2Service.TGetByID(model.About2ID);
                if (service == null)
                {
                    return NotFound();
                }

                service.Title1 = model.Title1;
                service.Description = model.Description;
                service.Title2 = model.Title2;

                if (model.newImage != null)
                {
                    // Eski resim dosyasını sil
                    if (!string.IsNullOrEmpty(service.Image))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageWhyUs/", service.Image);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Yeni resim dosyasını yükle
                    var extension = Path.GetExtension(model.newImage.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageWhyUs/", newImageName);
                    using (var stream = new FileStream(newImagePath, FileMode.Create))
                    {
                        model.newImage.CopyTo(stream);
                    }

                    // Yeni resim dosyası bilgisi güncellenir
                    service.Image = newImageName;
                }

                _about2Service.TUpdate(service);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [Route("DeleteWhyUs/{id}")]
        public IActionResult DeleteWhyUs(int id)
        {
            var service = _about2Service.TGetByID(id);
            if (service == null)
            {
                return NotFound();
            }

            // Resim dosyası silinir
            if (!string.IsNullOrEmpty(service.Image))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageWhyUs/", service.Image);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            // Servis silinir
            _about2Service.TDelete(service);

            return RedirectToAction("Index");
        }
    }
}
