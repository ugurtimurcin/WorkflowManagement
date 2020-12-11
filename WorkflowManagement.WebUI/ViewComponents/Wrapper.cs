using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DTO.DTOs.AppUserDTOs;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.ViewComponents
{
    public class Wrapper: ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public Wrapper(UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = _mapper.Map<AppUserListDTO>(user);

            ViewBag.NotificationsCount =  _notificationService.GetUnRead(user.Id).Count;

            var roles = _userManager.GetRolesAsync(user).Result;
            if (roles.Contains("Admin"))
            {
                return View(model);
            }

            return View("Member", model);
        }
    }
}
