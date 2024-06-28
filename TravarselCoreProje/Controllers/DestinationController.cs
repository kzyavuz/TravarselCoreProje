using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICatagoryService _catagoryService;

        public DestinationController(IDestinationService destinationService, UserManager<AppUser> userManager, ICatagoryService catagoryService)
        {
            _destinationService = destinationService;
            _userManager = userManager;
            _catagoryService = catagoryService;
        }

        [AllowAnonymous]
        public IActionResult Index(int? categoryId)
        {

            var destinations = _destinationService.TGetListByCatagoryDestination(categoryId, true);

            if (categoryId.HasValue)
            {
                var categoryName = _catagoryService.TGetByID(categoryId.Value);
                ViewBag.CategoryName = categoryName.CatagoryName; 
            }

            if (!destinations.Any())
            {
                ViewBag.Message = "Bu kategoriye ait etkinlik bulunamamıştır.";
            }
            else
            {
                ViewBag.Message = null; // Eğer etkinlik varsa mesajı temizle
            }
            return View(destinations);
        }

        [AllowAnonymous]
        public IActionResult LastIndex(int? categoryId)
        {

            var destinations = _destinationService.TGetListByCatagoryDestination(categoryId, false);

            if (categoryId.HasValue)
            {
                var categoryName = _catagoryService.TGetByID(categoryId.Value);
                ViewBag.CategoryName = categoryName.CatagoryName; 
            }

            if (!destinations.Any())
            {
                ViewBag.Message = "Bu kategoriye ait etkinlik bulunamamıştır.";
            }
            else
            {
                ViewBag.Message = null; // Eğer etkinlik varsa mesajı temizle
            }
            return View(destinations);
        }

        //[HttpGet]
        public async Task<IActionResult> DestinationDetails(int id)
        {
            ViewBag.i = id;
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = value.Id;
            var values = _destinationService.TGetDestinationsGuide(id);
            return View(values);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Destination/Search")]
        public IActionResult Search(int? categoryId, string city, string district, DateTime? date)
        {
            var destinations = _destinationService.TGetListByFilterDestinations(categoryId, city, district, date);

            if (!destinations.Any())
            {
                ViewBag.Message = "Bu kriterlere uygun etkinlik bulunamamıştır.";
            }
            else
            {
                ViewBag.Message = null;
            }

            return View("Index", destinations);
        }
    }
}
