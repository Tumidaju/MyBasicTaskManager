using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Models
{
    public class TaskFull
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CardColor { get; set; }
        public string FontColor { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public int Progres { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }
        public Rank Rank { get; set; }
        public UserSimple User { get; set; }
    }
}