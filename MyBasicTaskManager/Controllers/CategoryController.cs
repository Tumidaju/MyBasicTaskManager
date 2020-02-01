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
using MyBasicTaskManager.Interfaces;

namespace MyBasicTaskManager.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IUsersRepository _usersRepository;

        public CategoryController(ICategoryRepository categoryRepository, IUsersRepository usersRepository)
        {
            _categoryRepository = categoryRepository;
            _usersRepository = usersRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "My Categories";
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            var model = new CategoryList()
            {
                AllCategories = mapper.Map<List<Category>, List<CategoryViewModel>>(_categoryRepository.GetAll(_usersRepository.GetCurrentUserId())),
            };
            return View(model);
        }

        public ActionResult CategoryForm(bool IsExisting,int Id=0)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            var Viewmodel = new CategoryFormViewModel()
            {
                Category=new CategoryViewModel() { Id=0 }
            };
            if (IsExisting)
            {
                Viewmodel.Category = mapper.Map<Category, CategoryViewModel>(_categoryRepository.Get(Id, _usersRepository.GetCurrentUserId()));
                ViewBag.Title = "Edit category";
                Viewmodel.IsExisting = true;
            }
            else
            {
                ViewBag.Title = "Add new category";
                Viewmodel.IsExisting = false;
            } 
            return View(Viewmodel);
        }

        [HttpPost]
        public ActionResult CategoryForm(CategoryFormViewModel categoryFormViewModel)
        {
            TryValidateModel(categoryFormViewModel.Category);
            if (ModelState.IsValid)
            {
                _categoryRepository.Save(categoryFormViewModel.IsExisting, categoryFormViewModel.Category, _usersRepository.GetCurrentUserId());
                return RedirectToAction("Index");
            }
            else
                return View(categoryFormViewModel);
        }
        public ActionResult DeleteCategory(int Id)
        {
            _categoryRepository.Delete(Id, _usersRepository.GetCurrentUserId());
            return RedirectToAction("Index");
        }
    }
}