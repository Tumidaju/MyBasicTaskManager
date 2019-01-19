using MyBasicTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Services
{
    public class TasksService
    {
        //private readonly ApplicationDbContext _db = new ApplicationDbContext();
        public List<TaskFull> GetAll()
        {
            var model = new List<TaskFull>();
            ApplicationDbContext _db = new ApplicationDbContext();
            return model;
        }
        public TaskFull Get(int Id)
        {
            var model = new TaskFull();
            return model;
        }
        public bool Save(bool IsExisting,TaskFull Task)
        {
            return true;
        }
        public void Delete(int Id)
        {

        }
    }
}