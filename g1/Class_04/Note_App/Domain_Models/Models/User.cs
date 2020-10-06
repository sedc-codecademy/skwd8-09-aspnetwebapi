using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain_Models.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
