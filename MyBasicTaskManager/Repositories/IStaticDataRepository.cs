using MyBasicTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Repositories
{
    public interface IStaticDataRepository
    {
        List<Rank> GetRanks();
        List<Status> GetStatuses();
        List<Category> GetCategories();
        IEnumerable<SelectListItem> GetRanksDropdown();
        IEnumerable<SelectListItem> GetStatusesDropdown();
        IEnumerable<SelectListItem> GetCategoriesDropdown();
    }
}