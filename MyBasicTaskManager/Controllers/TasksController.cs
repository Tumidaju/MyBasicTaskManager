﻿using MyBasicTaskManager.Models;
using MyBasicTaskManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly TasksService _tasksService = new TasksService();
        public ActionResult Index()
        {
            ViewBag.Title = "My Tasks";
            var model = new TasksViewModel();
            return View(model);
        }
        public ActionResult TaskForm(bool IsExisting,int Id=0)
        {
            var Viewmodel = new TaskFormViewModel();
            if (IsExisting)
            {
                var model = _tasksService.Get(Id);
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
            //taskFormViewModel.Task.TryUpdateModel();
            if (ModelState.IsValid)
            {
                _tasksService.Save(taskFormViewModel.IsExisting, taskFormViewModel.Task);
                return RedirectToAction("Index");
            }
            else
            {
                return View(taskFormViewModel);
            } 
        }
        public ActionResult DeleteTask(int Id)
        {
             _tasksService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}