using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DTO.DTOs.JobDTOs;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;
        public JobController(IJobService jobService, IUrgencyService urgencyService, IMapper mapper)
        {
            _jobService = jobService;
            _urgencyService = urgencyService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "job";
            return View(_mapper.Map<List<JobListDTO>>(_jobService.GetJobsWithUrgenciesUnCompleted()));
        }

        public IActionResult AddJob()
        {
            TempData["Active"] = "job";

            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Title");
            return View(new JobAddDTO());
        }

        [HttpPost]
        public IActionResult AddJob(JobAddDTO model)
        {
            if (ModelState.IsValid)
            {
                var job = new Job()
                {
                    Title = model.Title,
                    Description = model.Description,
                    UrgencyId = model.UrgencyId
                };

                _jobService.Create(job);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult EditJob(int id)
        {
            TempData["Active"] = "job";
            var job = _jobService.GetById(id);
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Title", job.UrgencyId);
            return View(_mapper.Map<JobEditDTO>(job));
        }

        [HttpPost]
        public IActionResult EditJob(JobEditDTO model)
        {
            var job = _jobService.GetById(model.Id);
            if (ModelState.IsValid)
            {
                job.Title = model.Title;
                job.Description = model.Description;
                job.UrgencyId = model.UrgencyId;

                _jobService.Update(job);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult DeleteJob(int id)
        {
            _jobService.Delete(new Job { Id = id });
            return Json(null);
        }
    }
}
