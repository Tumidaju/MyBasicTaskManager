using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using MyBasicTaskManager.Interfaces;

namespace MyBasicTaskManager.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseModel _db;

        public CategoryRepository(DatabaseModel db)
        {
            _db = db;
        }

        public List<Category> GetAll(string UserId)
        {
            var model = _db.CATEGORY.Where(x => x.USER_ID == UserId).Select(x => new Category()
            {
                Id = x.ID,
                Name = x.NAME,
                Description=x.DESCRIPTION,
                Color = x.COLOR,
                UserId = UserId,
                IsUsedInTask=x.TASK.Count()>0
            }).ToList();
            return model;
        }

        public Category Get(int Id, string UserId)
        {
            var model = _db.CATEGORY.Where(x => x.USER_ID == UserId && x.ID == Id).Select(x => new Category()
            {
                Id = x.ID,
                Name = x.NAME,
                Description = x.DESCRIPTION,
                Color = x.COLOR,
                UserId = UserId,
                IsUsedInTask = x.TASK.Count() > 0
            }).FirstOrDefault();
            return model;
        }

        public void Save(bool IsExisting, CategoryViewModel Category, string UserId)
        {
            if (IsExisting)
            {
                var dataModel = _db.CATEGORY.Where(x => x.ID == Category.Id && x.USER_ID == UserId).First();         
                dataModel.NAME = Category.Name;
                dataModel.DESCRIPTION = Category.Description;
                dataModel.COLOR = Category.Color;
                _db.SaveChanges();
            }
            else
            {
                var dataModel = new CATEGORY()
                {
                    NAME = Category.Name,
                    DESCRIPTION=Category.Description,
                    COLOR= Category.Color,
                    USER_ID = UserId
                };
                _db.CATEGORY.Add(dataModel);
                _db.SaveChanges();
            }        
        }

        public void Delete(int CategoryId, string UserId)
        {
            var dataModel = _db.CATEGORY.Where(x => x.ID == CategoryId && x.USER_ID == UserId).First();
            if(dataModel.TASK.Count() == 0)
            {
                _db.CATEGORY.Remove(dataModel);
                _db.SaveChanges();
            }
        }
    }
}