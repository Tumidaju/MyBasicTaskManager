using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Models
{
    public class UsersViewModel
    {
        public List<UserFull> Users { get; set; }
        public string CurrentUserId { get; set; }
    }
}