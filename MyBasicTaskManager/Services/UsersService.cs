using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Services
{
    public class UsersService
    {
        private readonly DatabaseModel _db = new DatabaseModel();
        public List<UserFull> GetAll()
        {
            var model = new List<UserFull>();
            return model;
        }
        public string GetCurrentUserId()
        {
            var model = _db.AspNetUsers.Where(x => x.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault().Id;
            return model;
        }
        public UserFull Get(int Id)
        {
            var model = new UserFull();
            return model;
        }
        public bool Save(bool IsExisting,UserFull Task)
        {
            return true;
        }
        public void Delete(int Id)
        {

        }
    }
}