using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Models
{
    public class UserFormViewModel
    {
        public UserFull User { get; set; }
        public bool IsExisting { get; set; }
    }
}