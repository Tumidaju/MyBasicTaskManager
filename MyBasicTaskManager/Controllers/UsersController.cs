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
    public class UsersController : Controller
    {
        private readonly UsersService _usersService = new UsersService();

        public ActionResult Index()
        {
            ViewBag.Title = "Manage Users";
            var model = new UsersViewModel();
            return View(model);
        }
        public ActionResult UserForm(bool IsExisting, int Id = 0)
        {
            var Viewmodel = new UserFormViewModel();
            if (IsExisting)
            {
                var model = _usersService.Get(Id);
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
        public ActionResult UserForm(UserFormViewModel userFormViewModel)
        {
            //userFormViewModel.User.TryUpdateModel();
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
        public ActionResult DeleteUser(int Id)
        {
            _usersService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}