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
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles ="Member")]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public JobController(IJobService jobService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _jobService = jobService;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int activePage = 1)
        {
            TempData["Active"] = "job";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = _mapper.Map<List<JobListAllDTO>>(_jobService.GetByAllTablesUncompleted(out int totalPage, user.Id, activePage));

            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;

            return View(model);
        }
    }
}
