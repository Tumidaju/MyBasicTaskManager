using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Repositories
{
    public class StaticDataRepository
    {
        private readonly DatabaseModel _db = new DatabaseModel();
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
        public List<Category> GetCategories()
        {
            var model = _db.CATEGORY.Select(x => new Category()
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
        public IEnumerable<SelectListItem> GetCategoriesDropdown()
        {
            var model = _db.CATEGORY.Select(x => new SelectListItem()
            {
                Value = x.ID.ToString(),
                Text = x.NAME,
            }).ToList();
            return model;
        }

    }
}