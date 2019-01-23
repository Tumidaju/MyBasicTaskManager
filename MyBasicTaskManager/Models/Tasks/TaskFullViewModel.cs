using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Models
{
    public class TaskFullViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Card Color (Kanban)")]
        [Required(ErrorMessage = "Card Color is required")]
        public string CardColor { get; set; }
        [Display(Name = "Font Color (Kanban)")]
        [Required(ErrorMessage = "Font Color is required")]
        public string FontColor { get; set; }
        [Display(Name = "Deadline")]
        public DateTime? DeadlineDate { get; set; }
        [Display(Name = "Progres")]
        [Required(ErrorMessage = "Progres is required")]
        public int Progres { get; set; }
        [Display(Name = "Category")]
        public int Category { get; set; }
        [Display(Name = "Status")]
        public int Status { get; set; }
        [Display(Name = "Priority")]
        public int Rank { get; set; }
    }
}