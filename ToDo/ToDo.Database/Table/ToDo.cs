using System;
using System.ComponentModel.DataAnnotations;
using ToDo.Database.Table;

namespace ToDo.Database.Database.Table
{
    public class ToDo : BaseEntity
    {
        [Key]
        public int ToDoId { get; set; }

        [Required]
        public string Content { get; set; }
        public bool Status { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
