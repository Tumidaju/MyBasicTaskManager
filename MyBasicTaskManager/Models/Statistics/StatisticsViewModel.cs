using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Models
{
    public class StatisticsViewModel
    {
        public bool Active { get; set; }
        public int CreatedTasks { get; set; }
        public int FinishedTasks { get; set; }
        public int DeletedTasks { get; set; }
        public int TasksWithDeadline { get; set; }
        public int TasksFinishedBeforeDeadline { get; set; }
        public DateTime FirstTaskCreation { get; set; }
        public DateTime LastTaskCreation { get; set; }
    }
}