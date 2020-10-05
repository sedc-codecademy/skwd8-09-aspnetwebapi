using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SEDC.NotesApp.Domain.Enums;

namespace SEDC.NotesApp.Domain.Models
{
    public class Note
    {
        public int Id { get; set; }
        
        public string Text { get; set; }
      
        public string Color { get; set; }

        public TagType Tag { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
