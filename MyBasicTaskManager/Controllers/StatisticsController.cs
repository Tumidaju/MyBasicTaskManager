using AutoMapper;
using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using MyBasicTaskManager.Repositories;
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
        static DatabaseModel _db = new DatabaseModel();
        private readonly StatisticsRepository _statisticsRepository = new StatisticsRepository(_db);
        private readonly UsersRepository _usersRepository = new UsersRepository(_db);
        public ActionResult Index()
        {
            ViewBag.Title = "My Statistics";
            var ViewModel = new StatisticsViewModel() { Active=false};
            var model = _statisticsRepository.Get(_usersRepository.GetCurrentUserId());
            if(model!=null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<StatisticsFull, StatisticsViewModel>();
                });
                IMapper mapper = config.CreateMapper();
                ViewModel=mapper.Map<StatisticsFull, StatisticsViewModel>(model);
                ViewModel.Active = true;
            } 
            return View(ViewModel);
        }
    }
}