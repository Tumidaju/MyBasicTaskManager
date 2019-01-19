using MyBasicTaskManager.Models;
using MyBasicTaskManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly StatisticsService _statisticsController = new StatisticsService();
        public ActionResult Index()
        {
            ViewBag.Title = "My Statistics";
            var model = _statisticsController.Get();
            var ViewModel = new StatisticsViewModel();
            return View(ViewModel);
        }
    }
}