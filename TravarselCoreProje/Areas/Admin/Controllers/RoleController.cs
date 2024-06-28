using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravarselCoreProje.Areas.Admin.Models;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role/")]
    [Authorize(Policy = "AdminPolicy")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        [Route("AddRole")]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(RoleModel roleModel)
        {
            AppRole role = new AppRole()
            {
                Name = roleModel.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateRole/{id}")]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleModel roleModel = new RoleModel()
            {
                id = values.Id,
                RoleName = values.Name
            };
            return View(roleModel);
        }

        [HttpPost]
        [Route("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(RoleModel roleModel)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == roleModel.id);
            values.Name = roleModel.RoleName;
            await _roleManager.UpdateAsync(values);
            return RedirectToAction("Index");
        }



        [Route("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("AssignRole/{id}")]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["UserID"] = user.Id;   
            var rol = _roleManager.Roles.ToList();
            var userRole =await _userManager.GetRolesAsync(user);
            List<RoleAssignModel> roleAssignModels = new List<RoleAssignModel>();
            foreach (var item in rol)
            {
                RoleAssignModel model = new RoleAssignModel();
                model.RoleID = item.Id;
                model.RolName = item.Name;
                model.status = userRole.Contains(item.Name);
                roleAssignModels.Add(model);
            }
            return View(roleAssignModels);
        }
        
        
        [HttpPost]
        [Route("AssignRole/{id}")]
        public async Task<IActionResult> AssignRole(List<RoleAssignModel> model)
        {
            var userid = (int)TempData["UserID"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in model)
            {
                if (item.status)
                {
                    await _userManager.AddToRoleAsync(user, item.RolName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RolName);
                }
            }
            return RedirectToAction("Index", "User", new { area = "Admin" });
        }
    }
}
