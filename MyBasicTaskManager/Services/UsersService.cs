using MyBasicTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Services
{
    public class UsersService
    {
        public List<UserFull> GetAll()
        {
            var model = new List<UserFull>();
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