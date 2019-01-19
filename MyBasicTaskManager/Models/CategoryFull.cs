using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Models
{
    public class CategoryFull : Category
    {
        public List<TaskFull> Tasks { get; set; }
    }
}