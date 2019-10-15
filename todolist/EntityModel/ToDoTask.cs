namespace todolist.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ToDoTask
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long ListId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? DeadlineDate { get; set; }

        public byte? Status { get; set; }


        public DateTime? UpdateDate { get; set; }

        public virtual ToDoList ToDoList { get; set; }

        public virtual User User { get; set; }
    }
}
