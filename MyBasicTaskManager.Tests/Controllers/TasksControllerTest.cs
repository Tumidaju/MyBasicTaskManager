using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MyBasicTaskManager;
using MyBasicTaskManager.Controllers;
using NUnit.Framework;
using Moq;
using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using MyBasicTaskManager.Repositories;
using System.IO;
using System.Configuration;
using System.Web.Routing;
using System.Web;

namespace MyBasicTaskManager.Tests.Controllers
{
    [TestFixture]
    public class TasksControllerTest
    {
        private Mock<IUsersRepository> _usersRepository;
        private Mock<ITasksRepository> _tasksRepository;
        private Mock<IStaticDataRepository> _statidataRepository;

        [SetUp]
        public void Init()
        {
            _usersRepository = new Mock<IUsersRepository>();
            _tasksRepository = new Mock<ITasksRepository>();
            _statidataRepository = new Mock<IStaticDataRepository>();
        }

        [Test]
        public void Index_Invoked_ReturnsViewWithModelPropertyAllTasks()
        {
            // Arrange

            TasksController controller = new TasksController(_tasksRepository.Object,_statidataRepository.Object,_usersRepository.Object);         
            // Act

            ViewResult result = controller.Index() as ViewResult;
            var property = (TasksViewModel)result.Model;

            // Assert
            Assert.IsNotNull(property.AllTasks);
        }
        [Test]
        public void TaskForm_NewTaskRequest_ReturnsViewWithEmptyTaskModel()
        {
            // Arrange
            TasksController controller = new TasksController(_tasksRepository.Object, _statidataRepository.Object, _usersRepository.Object);

            // Act
            ViewResult result = controller.TaskForm(false) as ViewResult;
            var model = (TaskFormViewModel)result.ViewData.Model;

            // Assert
            Assert.AreEqual(false, model.IsExisting);
        }
        [Test]
        public void TaskForm_EditTaskRequest_ReturnsViewWithFilledTaskModel()
        {
            // Arrange
            TasksController controller = new TasksController(_tasksRepository.Object, _statidataRepository.Object, _usersRepository.Object);

            // Act
            ViewResult result = controller.TaskForm(true,3) as ViewResult;
            var model = (TaskFormViewModel)result.ViewData.Model;

            // Assert
            Assert.AreEqual(true, model.IsExisting);
        }       
        [Test]
        public void TaskForm_SaveUserModelIsInvalid_ReturnsTaskFormView()
        {
            // Arrange
            TasksController controller = new TasksController(_tasksRepository.Object, _statidataRepository.Object, _usersRepository.Object);
            var context = new Mock<HttpContextBase>();
            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);
            TaskFullViewModel EmptyTask = new TaskFullViewModel();
            TaskFormViewModel InvalidModel = new TaskFormViewModel() { Task= EmptyTask, IsExisting =false};

            // Act
            ViewResult result = controller.TaskForm(InvalidModel) as ViewResult;
            var model = (TaskFormViewModel)result.ViewData.Model;

            // Assert
            Assert.AreEqual(EmptyTask, model.Task);
        }
        [Test]
        public void TaskForm_SaveUserModelIsValid_ReturnsTasksIndexView()
        {
            // Arrange
            TasksController controller = new TasksController(_tasksRepository.Object, _statidataRepository.Object, _usersRepository.Object);
            var context = new Mock<HttpContextBase>();
            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);
            var uniquestring=DateTime.Now.ToBinary().ToString().Substring(3, 10);
            TaskFullViewModel ProperTask = new TaskFullViewModel() { Name = uniquestring, Description = uniquestring, CardColor ="#000", FontColor = "#000", Progres=0, Category=1,Status=1,Rank=1 };
            TaskFormViewModel ValidModel = new TaskFormViewModel() { Task = ProperTask, IsExisting = false };

            // Act
            var model = (RedirectToRouteResult)controller.TaskForm(ValidModel);

            // Assert
            Assert.AreEqual("Index", model.RouteValues["action"]);
        }
        [Test]
        public void TaskForm_DeleteTasl_ReturnsTasksIndexView()
        {
            // Arrange
            TasksController controller = new TasksController(_tasksRepository.Object, _statidataRepository.Object, _usersRepository.Object);

            // Act
            var model = (RedirectToRouteResult)controller.DeleteTask(3);

            // Assert
            Assert.AreEqual("Index", model.RouteValues["action"]);
        }

    }
}
