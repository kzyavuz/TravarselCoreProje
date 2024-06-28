using BusinessLayer.Abstract;
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
    [Area("Admin")]
    [Route("Admin/Catagory/")]
    [Authorize(Policy = "AdminPolicy")]
    public class CatagoryController : Controller
    {
        private readonly ICatagoryService _catagoryService;

        public CatagoryController(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _catagoryService.TGetList();
            return View(values);
        }

        [HttpGet]
        [Route("AddCatagory")]
        public IActionResult AddCatagory()
        {
            return View();
        }


        [Route("ConvertStandOut/{id}")]
        public IActionResult ConvertTrue(int id)
        {
            _catagoryService.TConvertTrueByCatagory(id);
            return RedirectToAction("Index");
        }

        [Route("ConvertHighlight/{id}")]
        public IActionResult ConvertFalse(int id)
        {
            _catagoryService.TConvertFalseByCatagory(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("AddCatagory")]
        public IActionResult AddCatagory(CatagoryViewModel model, Catagory p)
        {
            if (!ModelState.IsValid)
            {
                // Model doğrulaması başarısız
                return View(p);
            }

            if (model.CatagoryImage != null)
            {
                var extension = Path.GetExtension(model.CatagoryImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CatagoryImage/", newimagename);

                using (var stream = new FileStream(location, FileMode.Create))
                {
                    model.CatagoryImage.CopyTo(stream);

                }
                p.CatagoryImage = newimagename;
            }
            p.CatagoryName = model.CatagoryName;
            p.Status = true;

            try
            {
                _catagoryService.TAdd(p);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Katagori eklenirken bir hata oluştu: " + ex.Message);
            }

            return View(model);
        }


        [HttpGet]
        [Route("UpdateCatagory/{id}")]
        public IActionResult UpdateCatagory(int id)
        {
            var service = _catagoryService.TGetByID(id);
            if (service == null)
            {
                return NotFound();
            }

            var model = new CatagoryViewModel
            {
                CatagoryID = service.CatagoryID,
                CatagoryName = service.CatagoryName,
                ExistingImagePath = service.CatagoryImage // Mevcut resim dosyası yolunu sakla
            };

            return View(model);
        }

        [Route("UpdateCatagory/{id}")]
        [HttpPost]
        public IActionResult UpdateCatagory(CatagoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = _catagoryService.TGetByID(model.CatagoryID);
                if (service == null)
                {
                    return NotFound();
                }

                service.CatagoryName = model.CatagoryName;

                if (model.newCatagoryImage != null)
                {
                    // Eski resim dosyasını sil
                    if (!string.IsNullOrEmpty(service.CatagoryImage))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CatagoryImage/", service.CatagoryImage);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Yeni resim dosyasını yükle
                    var extension = Path.GetExtension(model.newCatagoryImage.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CatagoryImage/", newImageName);
                    using (var stream = new FileStream(newImagePath, FileMode.Create))
                    {
                        model.newCatagoryImage.CopyTo(stream);
                    }

                    // Yeni resim dosyası bilgisi güncellenir
                    service.CatagoryImage = newImageName;
                }

                _catagoryService.TUpdate(service);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpPost]
        [Route("DeleteCatagory/{id}")]
        public IActionResult DeleteCatagory(int id)
        {
            var service = _catagoryService.TGetByID(id);
            if (service == null)
            {
                return NotFound();
            }

            // Resim dosyası silinir
            if (!string.IsNullOrEmpty(service.CatagoryImage))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CatagoryImage/", service.CatagoryImage);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            // Servis silinir
            _catagoryService.TDelete(service);

            return RedirectToAction("Index");
        }
    }
}
