using MyBasicTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Services
{
    public class StatisticsService
    {
        public StatisticsFull Get()
        {
            var model = new StatisticsFull();
            return model;
        }
    }
}