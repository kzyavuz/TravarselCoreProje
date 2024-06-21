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
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _userManager = userManager;
        }

        public IActionResult Index(int? id)
        {

            if (id != null && id > 0)
            {
                var destinations = _destinationService.TGetList()
                   .Where(e => e.Catagory != null && e.Catagory.CatagoryID == id && e.Status == true)
                   .ToList();
                return View(destinations);

            }
            else
            {
                var destinations = _destinationService.TGetList().Where(x => x.Status == true).ToList();
                return View(destinations);
            }

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
    }
}
