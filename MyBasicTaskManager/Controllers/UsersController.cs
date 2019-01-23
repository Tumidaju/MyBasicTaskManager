using AutoMapper;
using MyBasicTaskManager.Models;
using MyBasicTaskManager.Repositories;
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
        private readonly UsersRepository _usersRepository = new UsersRepository();

        public ActionResult Index()
        {
            ViewBag.Title = "Manage Users";
            var model = new UsersViewModel()
            {
                Users = _usersRepository.GetAll(),
                CurrentUserId = _usersRepository.GetCurrentUserId()
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
                var user = _usersRepository.Get(Id);
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
                _usersRepository.Save(userFormViewModel.IsExisting, userFormViewModel.User);
                return RedirectToAction("Index");
            }
            else
            {
                return View(userFormViewModel);
            }
        }
        public ActionResult DeleteUser(string Id)
        {
            if(Id!=_usersRepository.GetCurrentUserId())
                _usersRepository.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}