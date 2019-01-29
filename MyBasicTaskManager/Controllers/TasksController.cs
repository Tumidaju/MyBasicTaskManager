using MyBasicTaskManager.Models;
using MyBasicTaskManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AutoMapper;
using MyBasicTaskManager.Models.Infrastructure;

namespace MyBasicTaskManager.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private ITasksRepository _tasksRepository;
        private IStaticDataRepository _staticDataRepository;
        private IUsersRepository _usersRepository;
        //static DatabaseModel _db = new DatabaseModel();
        //public TasksController()
        //{
        //    _tasksRepository = new TasksRepository(_db);
        //    _staticDataRepository = new StaticDataRepository(_db);
        //    _usersRepository = new UsersRepository(_db);
        //}

        public TasksController(ITasksRepository tasksRepository, IStaticDataRepository staticDataRepository, IUsersRepository usersRepository)
        {
            _tasksRepository = tasksRepository;
            _staticDataRepository = staticDataRepository;
            _usersRepository = usersRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "My Tasks";
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskFull, TaskViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            var model = new TasksViewModel()
            {
                AllTasks = mapper.Map<List<TaskFull>, List<TaskViewModel>>(_tasksRepository.GetAll(_usersRepository.GetCurrentUserId())),
            };
            return View(model);
        }
        public ActionResult TaskForm(bool IsExisting,int Id=0)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskFull, TaskFullViewModel>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Id)).ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Id)).ForMember(dest => dest.Rank, opt => opt.MapFrom(src => src.Rank.Id));
            });
            IMapper mapper = config.CreateMapper();
            var Viewmodel = new TaskFormViewModel()
            {
                RankList = _staticDataRepository.GetRanksDropdown(),
                CategoryList = _staticDataRepository.GetCategoriesDropdown(),
                StatusList = _staticDataRepository.GetStatusesDropdown(),
                Task=new TaskFullViewModel() { Id=0, Progres = 0 }
            };
            if (IsExisting)
            {
                Viewmodel.Task = mapper.Map<TaskFull, TaskFullViewModel>(_tasksRepository.Get(Id, _usersRepository.GetCurrentUserId()));
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
                _tasksRepository.Save(taskFormViewModel.IsExisting, taskFormViewModel.Task, _usersRepository.GetCurrentUserId());
                return RedirectToAction("Index");
            }
            else
            {
                taskFormViewModel.RankList = _staticDataRepository.GetRanksDropdown();
                taskFormViewModel.CategoryList = _staticDataRepository.GetCategoriesDropdown();
                taskFormViewModel.StatusList = _staticDataRepository.GetStatusesDropdown();
                return View(taskFormViewModel);
            }
        }
        public ActionResult DeleteTask(int Id)
        {
             _tasksRepository.Delete(Id, _usersRepository.GetCurrentUserId());
            return RedirectToAction("Index");
        }
    }
}