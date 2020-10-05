using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SEDC.NotesApp.Domain.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; } // recognizes Id as key (PK)
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        [Required]
        public string Username { get; set; }
        [NotMapped] //will not create a column for this prop
        public int Age { get; set; }
        [InverseProperty("User")]
        public List<Note> Notes { get; set; }
    }
}
