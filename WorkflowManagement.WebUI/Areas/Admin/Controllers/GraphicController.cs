using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowManagement.Business.Interfaces;

namespace WorkflowManagement.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class GraphicController : Controller
    {
        private readonly IAppUserService _appUserService;
        public GraphicController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "graphic";
            return View();
        }

        public IActionResult MostComplete()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetMostCompletedJobByEmployee());
            return Json(jsonString);
        }

        public IActionResult MostWorking()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetMostWorkingEmployee());
            return Json(jsonString);
        }
    }
}
