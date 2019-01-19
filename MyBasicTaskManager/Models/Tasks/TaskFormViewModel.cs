using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Models
{
    public class TaskFormViewModel
    {
        public TaskFull Task { get; set; }
        public bool IsExisting { get; set; }
        public List<Rank> RankList { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Status> StatusList { get; set; }
    }
}