using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Models
{
    public class UserFullViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail is required")]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}