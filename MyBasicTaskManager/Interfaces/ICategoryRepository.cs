using MyBasicTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll(string UserId);
        Category Get(int CategoryId, string UserId);
        void Save(bool IsExisting, CategoryViewModel User, string UserId);
        void Delete(int CategoryId, string UserId);
    }
}