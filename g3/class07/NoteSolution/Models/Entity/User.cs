using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entity
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }

        public string Password { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
