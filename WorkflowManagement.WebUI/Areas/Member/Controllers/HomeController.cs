using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles ="Admin, Member")]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IReportService _reportService;
        private readonly IJobService _jobService;
        private readonly INotificationService _notificationService;
        public HomeController(UserManager<AppUser> userManager, IReportService reportService, IJobService jobService, INotificationService notificationService)
        {
            _userManager = userManager;
            _reportService = reportService;
            _jobService = jobService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "home";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            ViewBag.ReportCount = _reportService.GetReportCountByUserId(user.Id);

            ViewBag.CompletedJobCount = _jobService.GetJobCountCompletedByUserId(user.Id);

            ViewBag.UnreadNotificationCount = _notificationService.GetUnreadNotificationCountByUserId(user.Id);

            ViewBag.UnCompletedJobCount = _jobService.GetJobCountUncompletedByUserId(user.Id);


            return View();
        }
    }
}
