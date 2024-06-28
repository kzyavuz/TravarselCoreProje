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
    [Route("Admin/Guide/")]
    [Authorize(Policy = "AdminPolicy")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideService.TGetList().OrderByDescending(x=> x.CreateGuide).ToList();
            return View(values);
        }

        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(GuideViewModel p, Guide s)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(s);
            if (result.IsValid)
            {
                if (p.Image != null)
                {
                    var extension = Path.GetExtension(p.Image.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageGuide/", newimagename);
                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        p.Image.CopyTo(stream);
                    }
                    s.Image = newimagename;
                }
                s.Name = p.name;
                s.InstagramUrl = p.InstagramUrl;
                s.TwitterUrl = p.TwitterUrl;
                s.Description = p.Description;
                s.CreateGuide = DateTime.Now;
                s.Status = true;

                try
                {
                    _guideService.TAdd(s);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Rehber eklenirken bir hata oluştu.");
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

        [Route("UpdateGuide/{id}")]
        [HttpGet]
        public IActionResult UpdateGuide(int id)
        {
            var service = _guideService.TGetByID(id);
            if (service == null)
            {
                return NotFound();
            }

            var model = new GuideViewModel
            {
                GuideID = service.GuideID,
                name = service.Name,
                InstagramUrl = service.InstagramUrl,
                TwitterUrl = service.TwitterUrl,
                Description = service.Description,
                ExistingImagePath = service.Image // Mevcut resim dosyası yolunu sakla
            };
            return View(model);
        }

        [Route("UpdateGuide/{id}")]
        [HttpPost]
        public IActionResult UpdateGuide(GuideViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = _guideService.TGetByID(model.GuideID);
                if (service == null)
                {
                    return NotFound();
                }

                service.Name = model.name;
                service.Description = model.Description;
                service.TwitterUrl = model.TwitterUrl;
                service.InstagramUrl = model.InstagramUrl;

                if (model.newImage != null)
                {
                    // Eski resim dosyasını sil
                    if (!string.IsNullOrEmpty(service.Image))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageGuide/", service.Image);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Yeni resim dosyasını yükle
                    var extension = Path.GetExtension(model.newImage.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageGuide/", newImageName);
                    using (var stream = new FileStream(newImagePath, FileMode.Create))
                    {
                        model.newImage.CopyTo(stream);
                    }

                    // Yeni resim dosyası bilgisi güncellenir
                    service.Image = newImageName;
                }

                _guideService.TUpdate(service);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [Route("DeleteGuide/{id}")]
        public IActionResult DeleteGuide(int id)
        {
            var service = _guideService.TGetByID(id);
            if (service == null)
            {
                return NotFound();
            }

            // Resim dosyası silinir
            if (!string.IsNullOrEmpty(service.Image))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageGuide/", service.Image);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            // Servis silinir
            _guideService.TDelete(service);

            return RedirectToAction("Index");
        }

        [Route("ConvertTrue/{id}")]
        public IActionResult ConvertTrue(int id)
        {
            _guideService.TConvertTrueByGuid(id);
            return RedirectToAction("Index");
        }

        [Route("ConvertFalse/{id}")]
        public IActionResult ConvertFalse(int id)
        {
            _guideService.TConvertFalseByGuid(id);
            return RedirectToAction("Index");
        }

        [Route("ConvertStandOut/{id}")]
        public IActionResult ConvertStandOut(int id)
        {
            _guideService.TConvertStandOutByGuid(id);
            return RedirectToAction("Index");
        }

        [Route("ConvertHighlight/{id}")]
        public IActionResult ConvertHighlight(int id)
        {
            _guideService.TConvertHighlightByGuid(id);
            return RedirectToAction("Index");
        }
    }
}
