using MyBasicTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Interfaces
{
    public interface IStaticDataRepository
    {
        List<Rank> GetRanks();
        List<Status> GetStatuses();
        List<Category> GetCategories(string UserId);
        IEnumerable<SelectListItem> GetRanksDropdown();
        IEnumerable<SelectListItem> GetStatusesDropdown();
        IEnumerable<SelectListItem> GetCategoriesDropdown(string UserId);
    }
}