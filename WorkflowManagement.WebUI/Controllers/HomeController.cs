using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DTO.DTOs.AppUserDTOs;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICustomLogger _logger;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICustomLogger logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDTO model)
        {

            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(a => a.UserName == model.UserName);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

                    if (result.Succeeded)
                    {
                        var role = await _userManager.GetRolesAsync(user);
                        if (role.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }
                }

                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }

            return View("Index", model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.UserName,
                    Picture = "default-pp.png"
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return View("Index");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


        public IActionResult StatusCode(int? code)
        {
            if (code == 404)
            {
                ViewBag.Code = code;
                ViewBag.Message = "Sayfa bulunamadı";
            }

            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _logger.LogError($"Hatanın oluştuğu yer: {exceptionHandler.Path}\nHata Mesajı: {exceptionHandler.Error.Message}\nStack Trace: {exceptionHandler.Error.StackTrace}");
            ViewBag.Path = exceptionHandler.Path;
            ViewBag.Message = exceptionHandler.Error.Message;
            return View();
        }

        public void Hata()
        {
            throw new Exception("Bu bir hata");
        }
    }
}
