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
    }
}