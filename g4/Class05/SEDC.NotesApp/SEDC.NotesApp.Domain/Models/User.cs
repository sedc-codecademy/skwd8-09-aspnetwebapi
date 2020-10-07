using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SEDC.NotesApp.Domain.Models
{
    public class User
    {
        public int Id { get; set; } // recognizes Id as key (PK)
        [MaxLength(100)]
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
        
        public string Username { get; set; }
        public int Age { get; set; }
       
        public List<Note> Notes { get; set; }
    }
}
