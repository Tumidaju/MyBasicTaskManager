using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Services
{
    public class StatisticsService
    {
        private readonly DatabaseModel _db = new DatabaseModel();
        public StatisticsFull Get()
        {
            var model = new StatisticsFull();
            return model;
        }
    }
}