using MyBasicTaskManager.Models;
using MyBasicTaskManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AutoMapper;

namespace MyBasicTaskManager.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly TasksService _tasksService = new TasksService();
        private readonly StaticDataService _staticDataService = new StaticDataService();
        private readonly UsersService _usersService = new UsersService();
        public ActionResult Index()
        {
            ViewBag.Title = "My Tasks";
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskFull, TaskViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            var model = new TasksViewModel()
            {
                AllTasks = mapper.Map<List<TaskFull>, List<TaskViewModel>>(_tasksService.GetAll(_usersService.GetCurrentUserId())),
            };
            return View(model);
        }
        public ActionResult TaskForm(bool IsExisting,int Id=0)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskFull, TaskFullViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            var Viewmodel = new TaskFormViewModel()
            {
                RankList = _staticDataService.GetRanksDropdown(),
                CategoryList = _staticDataService.GetCategoriesDropdown(),
                StatusList = _staticDataService.GetStatusesDropdown(),
                Task=new TaskFullViewModel() { Id=0, Progres = 0 }
            };
            if (IsExisting)
            {
                Viewmodel.Task = mapper.Map<TaskFull, TaskFullViewModel>(_tasksService.Get(Id, _usersService.GetCurrentUserId()));
                ViewBag.Title = "Edit task";
                Viewmodel.IsExisting = true;
            }
            else
            {
                ViewBag.Title = "Add new task";
                Viewmodel.IsExisting = false;
            } 
            return View(Viewmodel);
        }
        [HttpPost]
        public ActionResult TaskForm(TaskFormViewModel taskFormViewModel)
        {
            TryValidateModel(taskFormViewModel.Task);
            if (ModelState.IsValid)
            {
                _tasksService.Save(taskFormViewModel.IsExisting, taskFormViewModel.Task, _usersService.GetCurrentUserId());
                return RedirectToAction("Index");
            }
            else
            {
                taskFormViewModel.RankList = _staticDataService.GetRanksDropdown();
                taskFormViewModel.CategoryList = _staticDataService.GetCategoriesDropdown();
                taskFormViewModel.StatusList = _staticDataService.GetStatusesDropdown();
                return View(taskFormViewModel);
            }
        }
        public ActionResult DeleteTask(int Id)
        {
             _tasksService.Delete(Id, _usersService.GetCurrentUserId());
            return RedirectToAction("Index");
        }
    }
}