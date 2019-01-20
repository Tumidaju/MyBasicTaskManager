using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Models
{
    public class UserFormViewModel
    {
        public UserFullViewModel User { get; set; }
        public bool IsExisting { get; set; }
    }
}