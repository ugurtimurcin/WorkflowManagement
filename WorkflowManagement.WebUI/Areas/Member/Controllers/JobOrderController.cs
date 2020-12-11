using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DTO.DTOs.JobDTOs;
using WorkflowManagement.DTO.DTOs.ReportDTOs;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles ="Member")]
    public class JobOrderController : Controller
    {
        private readonly IJobService _jobService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IReportService _reportService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public JobOrderController(IJobService jobService, UserManager<AppUser> userManager, IReportService reportService, INotificationService notificationService, IMapper mapper)
        {
            _jobService = jobService;
            _userManager = userManager;
            _reportService = reportService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "jobOrder";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            return View(_mapper.Map<List<JobListAllDTO>>(_jobService.GetAllWithTables(a => a.AppUserId == user.Id && !a.State)));
        }

        public IActionResult AddReport(int id)
        {
            TempData["Active"] = "jobOrder";
            var job = _jobService.GetByIdWithUrgency(id);
            var model = new ReportAddDTO
            {
                JobId = id,
                Job = job
            };
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddReport(ReportAddDTO model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Create(new Report()
                {
                    JobId = model.JobId,
                    Title = model.Title,
                    Description = model.Description
                });

                var adminList = await _userManager.GetUsersInRoleAsync("Admin");
                var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);

                foreach (var admin in adminList)
                {
                    _notificationService.Create(new Notification()
                    {
                        Description = $"{activeUser.FirstName} {activeUser.LastName} yeni bir rapor yazdı.",
                        AppUserId = admin.Id
                    });
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult EditReport(int id)
        {
            TempData["Active"] = "jobOrder";
            
            return View(_mapper.Map<ReportEditDTO>(_reportService.GetByIdWJob(id)));
        }

        [HttpPost]
        public IActionResult EditReport(ReportEditDTO model)
        {
            if (ModelState.IsValid)
            {
                var report = _reportService.GetById(model.Id);

                report.Title = model.Title;
                report.Description = model.Description;

                _reportService.Update(report);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> CompleteJob(int jobId)
        {
            var jobToUpdate = _jobService.GetById(jobId);
            jobToUpdate.State = true;
            _jobService.Update(jobToUpdate);

            var adminList = await _userManager.GetUsersInRoleAsync("Admin");
            var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);

            foreach (var admin in adminList)
            {
                _notificationService.Create(new Notification()
                {
                    Description = $"{activeUser.FirstName} {activeUser.LastName} verilen görevi tamamladı.",
                    AppUserId = admin.Id
                });
            }


            return Json(null);
        }
    }
}
