using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Models
{
    public class UserFull
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; }
        public int NumberOfTasks { get; set; }
    }
}