using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Models
{
    public class TaskFormViewModel
    {
        public TaskFullViewModel Task { get; set; }
        public bool IsExisting { get; set; }
        public IEnumerable<SelectListItem> RankList { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
    }
}