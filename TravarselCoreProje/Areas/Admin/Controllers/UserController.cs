using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IRezervationService _rezervationService;

        public UserController(IAppUserService appUserService, IRezervationService rezervationService)
        {
            _appUserService = appUserService;
            _rezervationService = rezervationService;
        }

        public IActionResult Index()
        {
            var values = _appUserService.TGetList();
            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var vaslues = _appUserService.TGetByID(id);
            _appUserService.TDelete(vaslues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
           _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult CommentUser(int id)
        {
            _appUserService.TGetList();
            return View();
        }

        public IActionResult RezarvationUser(int id)
        {
            var values = _rezervationService.GetListRzervationByAcceptted(id);
            return View(values);
        }
    }
}
