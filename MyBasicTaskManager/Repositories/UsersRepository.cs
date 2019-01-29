using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DatabaseModel _db;
        private ITasksRepository _tasksRepository;

        public UsersRepository(DatabaseModel db)
        {
            _db = db;
            _tasksRepository = new TasksRepository(db);
        }

        public List<UserFull> GetAll()
        {
            var model = _db.AspNetUsers.Select(x => new UserFull()
            {
                Id = x.Id,
                Email = x.Email,
                Username = x.UserName,
                Roles = x.AspNetRoles.Select(r => new Role() { Id = r.Id }).ToList(),
                NumberOfTasks=x.TASK.Count()
            }).ToList();            
            return model;
        }
        public string GetCurrentUserId()
        {
            var name = "";
            if (HttpContext.Current!=null)
                name = HttpContext.Current.User.Identity.Name;
            var model = _db.AspNetUsers.Where(x => x.Email == name).FirstOrDefault();
            if (model != null)
                return model.Id;
            else
                return name;
        }
        public UserFull Get(string UserId)
        {
            var model = _db.AspNetUsers.Where(x => x.Id == UserId).Select(x => new UserFull()
            {
                Id = x.Id,
                Email=x.Email,
                Username=x.UserName,
                Roles=x.AspNetRoles.Select(r=> new Role() { Id=r.Id}).ToList(),
            }).FirstOrDefault();
            return model;
        }
        public void Save(bool IsExisting,UserFullViewModel User)
        {
            using (_db)
            {
                if (IsExisting)
                {
                    var dataModel = _db.AspNetUsers.Where(x => x.Id == User.Id).First();
                    dataModel.Id = User.Id;
                    dataModel.Email = User.Email;
                    dataModel.UserName = User.Username;
                    if (User.IsAdmin)
                    {
                        var adminrole = _db.AspNetRoles.FirstOrDefault();
                        dataModel.AspNetRoles.Add(adminrole);
                    }
                }
                _db.SaveChanges();
            }
        }
        public void Delete(string UserId)
        {
            using (_db)
            {
                var dataModel = _db.AspNetUsers.Where(x => x.Id == UserId).First();
                _db.AspNetUsers.Remove(dataModel);
                _db.SaveChanges();
            }
        }
    }
}