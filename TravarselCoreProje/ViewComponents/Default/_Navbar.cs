using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravarselCoreProje.Models;

public class _Navbar : ViewComponent
{
    private readonly ICatagoryService _catagoryService;
    private readonly UserManager<AppUser> _userManager;

    public _Navbar(ICatagoryService catagoryService, UserManager<AppUser> userManager)
    {
        _catagoryService = catagoryService;
        _userManager = userManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var data = _catagoryService.TGetList();

        var userRoles = new List<string>();
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);
            if (user != null)
            {
                userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            }
        }

        var viewModel = new NavbarViewModel
        {
            Catagories = data,
            UserRoles = userRoles
        };

        return View(viewModel);
    }
}
