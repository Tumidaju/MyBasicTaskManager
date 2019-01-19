using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Services
{
    public class StaticDataService
    {
        private readonly DatabaseModel _db = new DatabaseModel();
        public List<Rank> GetRanks()
        {
            var model = new List<Rank>();
            
            return model;
        }
        public List<Status> GetStatuses()
        {
            var model = new List<Status>();

            return model;
        }
        public List<Category> GetCategories()
        {
            var model = new List<Category>();

            return model;
        }
    }
}