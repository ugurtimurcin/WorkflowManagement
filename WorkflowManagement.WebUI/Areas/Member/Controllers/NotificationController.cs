using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DTO.DTOs.NotificationDTOs;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles ="Member")]
    public class NotificationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationController(UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "notification";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(_mapper.Map<List<NotificationListDTO>>(_notificationService.GetUnRead(user.Id)));
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var notificationToUpdate = _notificationService.GetById(id);
            notificationToUpdate.State = true;
            _notificationService.Update(notificationToUpdate);
            return RedirectToAction("Index");
        }
    }
}
