namespace MyBasicTaskManager.Models.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STATISTICS
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string USER_ID { get; set; }

        public int? CREATED_TASKS { get; set; }

        public int? FINISHED_TASKS { get; set; }

        public int? DELETED_TASKS { get; set; }

        public int? TASKS_WITH_DEADLINE { get; set; }

        public int? TASKS_FINISHED_BEFORE_DEADLINE { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? FIRST_TASK_CREATION { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LAST_TAKS_CREATION { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
