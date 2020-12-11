using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DTO.DTOs.AppUserDTOs;
using WorkflowManagement.DTO.DTOs.AssignEmployeeDTOs;
using WorkflowManagement.DTO.DTOs.JobDTOs;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class JobOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IJobService _jobService;
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public JobOrderController(IAppUserService appUserService, IJobService jobService, UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper)
        {
            _appUserService = appUserService;
            _jobService = jobService;
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "jobOrder";

            return View(_mapper.Map<List<JobListAllDTO>>(_jobService.GetAllWithTables()));
        }


        public IActionResult AssignEmployee(int id, string q, int page=1)
        {
            TempData["Active"] = "jobOrder";
            ViewBag.ActivePage = page;

            var employees = _mapper.Map<List<AppUserListDTO>>(_appUserService.GetNonAdmin(out int totalPage, q, page));
            ViewBag.TotalPage = totalPage;
            

            ViewBag.Employees = employees;

            
            return View(_mapper.Map<JobListDTO>(_jobService.GetByIdWithUrgency(id)));
        }

        [HttpPost]
        public IActionResult AssignEmployee(AssignEmployeeDTO model)
        {

            var updatedModel = _jobService.GetById(model.JobId);
            updatedModel.AppUserId = model.EmployeeId;

            _jobService.Update(updatedModel);

            _notificationService.Create(new Notification()
            {
                AppUserId = model.EmployeeId,
                Description = $"{updatedModel.Title} adlı iş için görevlendirildiniz."
            });

            return RedirectToAction("Index");
        }


        public IActionResult AssignJobEmployee(AssignEmployeeDTO model)
        {
            TempData["Active"] = "jobOrder";

            var userModel = _mapper.Map<AppUserListDTO>(_userManager.Users.FirstOrDefault(i => i.Id == model.EmployeeId));


            var jobModel = _mapper.Map<JobListDTO>(_jobService.GetByIdWithUrgency(model.JobId));

            var assingEmpModel = new AssignEmployeeListDTO()
            {
                AppUser = userModel,
                Job = jobModel
            };

            return View(assingEmpModel);
        }

        public IActionResult Detail(int id)
        {
            TempData["Active"] = "jobOrder";
            return View(_mapper.Map<JobListAllDTO>(_jobService.GetByIdWReports(id)));
        }
    }
}
