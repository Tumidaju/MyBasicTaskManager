using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Models
{
    public class CategoryFormViewModel
    {
        public CategoryViewModel Category { get; set; }
        public bool IsExisting { get; set; }
    }
}