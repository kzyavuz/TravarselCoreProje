using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravarselCoreProje.Areas.Admin.Models;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Blog/")]
    [Authorize(Policy = "AdminPolicy")]
    public class BlogController : Controller
    {
        private readonly Context _context;
        private readonly IBlogService _blogService;

        public BlogController(Context context, IBlogService blogService)
        {
            _context = context;
            _blogService = blogService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _context.Blogs.Include(x => x.AppUser).OrderByDescending(x => x.Created).ToListAsync();
            return View(values);
        }

        [Route("AddBlog")]
        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }

        [Route("AddBlog")]
        [HttpPost]
        public IActionResult AddBlog(AddBlogModel p)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı kimliğini al
                var adminUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // Kullanıcı kimliğini int'e çevir
                if (int.TryParse(adminUserId, out int userId))
                {
                    var now = DateTime.Now;
                    // Blog nesnesi oluştur
                    Blog s = new Blog();

                    // Eğer resim varsa işle
                    if (p.Image != null)
                    {
                        var extension = Path.GetExtension(p.Image.FileName);
                        var newImageName = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogImage/", newImageName);

                        // Resmi kaydet
                        using (var stream = new FileStream(location, FileMode.Create))
                        {
                            p.Image.CopyTo(stream);
                        }

                        // Resim yolu Blog nesnesine ekle
                        s.ImagePath = newImageName;
                    }

                    // Diğer Blog özelliklerini ayarla
                    s.Title = p.Title;
                    s.SubTitle = p.Description;
                    s.Content = p.DetailDescription;
                    s.Created = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
                    s.AppUserID = userId;

                    try
                    {
                        _blogService.TAdd(s);
                        return RedirectToAction("Index", "Blog");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Blog eklenirken bir hata oluştu.");

                    }
                }
                ModelState.AddModelError("", "Kullanıcı kimliği alınamadı.");
                return View(p);
            }
            return View(p);
        }

        [HttpPost]
        [Route("DeleteBlog/{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var blog = _blogService.TGetByID(id);
            if (blog == null)
            {
                return NotFound();
            }

            // Resim dosyasını sil
            if (!string.IsNullOrEmpty(blog.ImagePath))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogImage/", blog.ImagePath);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _blogService.TDelete(blog);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("UpdateBlog/{id}")]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _blogService.TGetByID(id);
            if (blog == null)
            {
                return NotFound();
            }

            var model = new UpdateBlogModel
            {
                Id = blog.BlogId,
                Title = blog.Title,
                Description = blog.SubTitle,
                DetailDescription = blog.Content,
                ImageUrl = blog.ImagePath // Mevcut resim dosyası yolunu sakla
            };

            return View(model);
        }

        [HttpPost]
        [Route("UpdateBlog/{id}")]
        public IActionResult UpdateBlog(UpdateBlogModel model)
        {
            if (ModelState.IsValid)
            {
                var adminUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (int.TryParse(adminUserId, out int userId))
                {
                    var _bM = _blogService.TGetByID(model.Id);
                    if (_bM == null)
                    {
                        return NotFound();
                    }

                    _bM.Title = model.Title;
                    _bM.SubTitle = model.Description;
                    _bM.Content = model.DetailDescription;

                    if (model.NewImageFile != null)
                    {
                        // Eski resim dosyasını sil
                        if (!string.IsNullOrEmpty(_bM.ImagePath))
                        {
                            var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogImage/", _bM.ImagePath);
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        // Yeni resim dosyasını yükle
                        var extension = Path.GetExtension(model.NewImageFile.FileName);
                        var newImageName = Guid.NewGuid() + extension;
                        var newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogImage/", newImageName);
                        using (var stream = new FileStream(newImagePath, FileMode.Create))
                        {
                            model.NewImageFile.CopyTo(stream);
                        }

                        // Yeni resim dosyası bilgisi güncellenir
                        _bM.ImagePath = newImageName;
                    }

                    _blogService.TUpdate(_bM);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}

