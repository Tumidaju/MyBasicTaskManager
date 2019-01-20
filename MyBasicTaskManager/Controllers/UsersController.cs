using AutoMapper;
using MyBasicTaskManager.Models;
using MyBasicTaskManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Controllers
{
    [Authorize(Roles ="admin")]
    public class UsersController : Controller
    {
        private readonly UsersService _usersService = new UsersService();

        public ActionResult Index()
        {
            ViewBag.Title = "Manage Users";
            var model = new UsersViewModel()
            {
                Users = _usersService.GetAll(),
                CurrentUserId = _usersService.GetCurrentUserId()
            };
            return View(model);
        }
        public ActionResult UserForm(bool IsExisting, string Id)
        {
            var Viewmodel = new UserFormViewModel();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserFull, UserFullViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            if (IsExisting)
            {
                ViewBag.Title = "Edit user";
                Viewmodel.IsExisting = true;
                var user = _usersService.Get(Id);
                Viewmodel.User= mapper.Map<UserFull, UserFullViewModel>(user);
                if (user.Roles.Count() > 0)
                    Viewmodel.User.IsAdmin = true;
            }
            return View(Viewmodel);
        }
        [HttpPost]
        public ActionResult UserForm(UserFormViewModel userFormViewModel)
        {
            TryValidateModel(userFormViewModel.User);
            if (ModelState.IsValid)
            {
                _usersService.Save(userFormViewModel.IsExisting, userFormViewModel.User);
                return RedirectToAction("Index");
            }
            else
            {
                return View(userFormViewModel);
            }
        }
        public ActionResult DeleteUser(string Id)
        {
            if(Id!=_usersService.GetCurrentUserId())
                _usersService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}