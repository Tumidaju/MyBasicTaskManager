using MyBasicTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Repositories
{
    public interface ITasksRepository
    {
        List<TaskFull> GetAll(string UserId);
        TaskFull Get(int Id, string UserId);
        void Save(bool IsExisting, TaskFullViewModel Task, string UserId);
        void Delete(int Id, string UserId);
        void ClearData(string UserId);
    }
}