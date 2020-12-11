using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly IJobService _jobService;
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IReportService _reportService;
        public HomeController(IJobService jobService, UserManager<AppUser> userManager, INotificationService notificationService, IReportService reportService)
        {
            _jobService = jobService;
            _userManager = userManager;
            _notificationService = notificationService;
            _reportService = reportService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "home";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.JobToAssign = _jobService.GetJobToAssignCount();
            ViewBag.CompletedJobCount = _jobService.GetCompletedJobCount();
            ViewBag.UnreadNotification = _notificationService.GetUnreadNotificationCountByUserId(user.Id);
            ViewBag.ReportCount = _reportService.GetReportCount();
            return View();
        }
    }
}
