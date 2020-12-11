using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DTO.DTOs.UrgencyDTOs;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;
        public UrgencyController(IUrgencyService urgencyService, IMapper mapper)
        {
            _urgencyService = urgencyService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "urgency";
            return View(_mapper.Map<List<UrgencyListDTO>>(_urgencyService.GetAll()));
        }

        public IActionResult AddUrgency()
        {
            TempData["Active"] = "urgency";
            var model = new UrgencyAddDTO();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddDTO model)
        {
            if (ModelState.IsValid)
            {
                var urgency = new Urgency()
                {
                    Title = model.Title
                };

                _urgencyService.Create(urgency);
                return RedirectToAction("Index");
            }

            return View(model);

        }

        public IActionResult EditUrgency(int id)
        {
            TempData["Active"] = "urgency";
            return View(_mapper.Map<UrgencyEditDTO>(_urgencyService.GetById(id)));
        }
        
        [HttpPost]
        public IActionResult EditUrgency(UrgencyEditDTO model)
        {
            var urgency = _urgencyService.GetById(model.Id);

            if (ModelState.IsValid)
            {
                urgency.Title = model.Title;
                _urgencyService.Update(urgency);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult DeleteUrgency(int id)
        {
            var model = _urgencyService.GetById(id);
            if (model != null)
            {
                _urgencyService.Delete(model);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
