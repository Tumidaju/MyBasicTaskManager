using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Repositories
{
    public class UsersRepository
    {
        private readonly DatabaseModel _db = new DatabaseModel();
        private readonly TasksRepository _tasksRepository = new TasksRepository();
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
            var model = _db.AspNetUsers.Where(x => x.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault().Id;
            return model;
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