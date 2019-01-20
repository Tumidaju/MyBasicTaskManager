namespace MyBasicTaskManager.Models.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TASK")]
    public partial class TASK
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NAME { get; set; }

        [Required]
        [StringLength(255)]
        public string DESCRIPTION { get; set; }

        [Required]
        [StringLength(10)]
        public string CARD_COLOR { get; set; }

        [Required]
        [StringLength(10)]
        public string FONT_COLOR { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CREATION_DATE { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LAST_EDIT_DATE { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? COMPLETION_DATE { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DEADLINE_DATE { get; set; }

        public int PROGRES { get; set; }

        public int CATEGORY_ID { get; set; }

        public int RANK_ID { get; set; }

        public int STATUS_ID { get; set; }

        [Required]
        [StringLength(128)]
        public string USER_ID { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        public virtual RANK RANK { get; set; }

        public virtual STATUS STATUS { get; set; }
    }
}