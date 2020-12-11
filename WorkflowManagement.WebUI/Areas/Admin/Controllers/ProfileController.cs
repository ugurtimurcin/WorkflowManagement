using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkflowManagement.DTO.DTOs.AppUserDTOs;
using WorkflowManagement.Entities.Concrete;
namespace WorkflowManagement.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public ProfileController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "myProfile";
            return View(_mapper.Map<AppUserListDTO>(await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDTO model, IFormFile pic)
        {
            if (ModelState.IsValid)
            {
                var user =  _userManager.Users.FirstOrDefault(s => s.Id == model.Id);
                if (pic != null)
                {
                    var extension = Path.GetExtension(pic.FileName);
                    var picName = Guid.NewGuid() + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + picName);
                    using var stream = new FileStream(path, FileMode.Create);
                    await pic.CopyToAsync(stream);

                    user.Picture = picName;
                }

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işlemi başarılı ile gerçekleşti.";
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
