using MyBasicTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Interfaces
{
    public interface IUsersRepository
    {
        List<UserFull> GetAll();
        string GetCurrentUserId();
        UserFull Get(string UserId);
        void Save(bool IsExisting, UserFullViewModel User);
        void Delete(string UserId);
    }
}