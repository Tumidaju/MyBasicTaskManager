using MyBasicTaskManager.Interfaces;
using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Repositories
{
    public class StaticDataRepository : IStaticDataRepository
    {
        private readonly DatabaseModel _db;

        public StaticDataRepository(DatabaseModel db)
        {
            _db = db;
        }

        public List<Rank> GetRanks()
        {
            var model = _db.RANK.Select(x => new Rank()
            {
                Id=x.ID,
                Name=x.NAME,
                Color=x.COLOR,
            }).ToList();
            return model;
        }
        public List<Status> GetStatuses()
        {
            var model = _db.STATUS.Select(x => new Status()
            {
                Id = x.ID,
                Name = x.NAME,
                Color = x.COLOR,
            }).ToList();
            return model;
        }
        public List<Category> GetCategories(string UserId)
        {
            var model = _db.CATEGORY.Where(x=>x.USER_ID==UserId).Select(x => new Category()
            {
                Id = x.ID,
                Name = x.NAME,
                Color = x.COLOR,
            }).ToList();
            return model;
        } 

        public IEnumerable<SelectListItem> GetRanksDropdown()
        {
            var model = _db.RANK.Select(x => new SelectListItem()
            {
                Value = x.ID.ToString(),
                Text = x.NAME,
            }).ToList();
            return model;
        }
        public IEnumerable<SelectListItem> GetStatusesDropdown()
        {
            var model = _db.STATUS.Select(x => new SelectListItem()
            {
                Value = x.ID.ToString(),
                Text = x.NAME,
            }).ToList();
            return model;
        }
        public IEnumerable<SelectListItem> GetCategoriesDropdown(string UserId)
        {
            var model = _db.CATEGORY.Where(x => x.USER_ID == UserId).Select(x => new SelectListItem()
            {
                Value = x.ID.ToString(),
                Text = x.NAME,
            }).ToList();
            return model;
        }

    }
}