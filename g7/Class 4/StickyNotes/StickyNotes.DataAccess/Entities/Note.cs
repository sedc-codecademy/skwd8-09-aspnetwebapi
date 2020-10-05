using StickyNotes.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StickyNotes.DataAccess.Entities
{
    [Table("Note")]
    public partial class Note
    {
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Text { get; set; }
        
        public ColorType? Color { get; set; }

        public int UserFk { get; set; }

        public User UserFkNavigation { get; set; }
    }
}
