using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using TravarselCoreProje.Models;

namespace TravarselCoreProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        IdentityValidator IdentityValidator = new IdentityValidator();
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p, string password)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(p.Mail);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Bu e-posta adresi zaten kullanılıyor.");
                    return View(p);
                }

                AppUser appUser = new AppUser()
                {
                    Name = p.Name,
                    NamSurname = p.Surname,
                    Email = p.Mail,
                    UserName = p.UserName
                };
                if (string.IsNullOrEmpty(password))
                {
                }
                else
                {
                    if (p.Password == p.ConfirmPassword)
                    {
                        var result = await _userManager.CreateAsync(appUser, p.Password);
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(appUser, "Member");
                            return RedirectToAction("SignIn");
                        }
                        else
                        {
                            foreach (var item in result.Errors)
                            {
                                ModelState.AddModelError("", item.Description);
                            }
                        }
                    }
                }
                return View(p);
            }
            else
            {
                return View(p);
            }
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(p.UserName);
                    if (user != null)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        if (roles.Contains("admin"))
                        {
                            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                        }
                        else if (roles.Contains("member"))
                        {
                            return RedirectToAction("MemberDashboard", "Dashboard", new { area = "Member" });
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                    return View(p);
                }
            }
            return View(p);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default", new { area = "" });
        }
    }
}
