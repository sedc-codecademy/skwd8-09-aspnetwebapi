using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Dapper.Contrib.Extensions;
using SEDC.NotesApp.Domain.Enums;

namespace SEDC.NotesApp.Domain.Models
{
    [Dapper.Contrib.Extensions.Table("Notes")]
    public class Note
    {
        public int Id { get; set; }
        
        public string Text { get; set; }
      
        public string Color { get; set; }

        public TagType Tag { get; set; }
        public int UserId { get; set; }
        [Computed] // dapper - ignore
        public User User { get; set; }
    }
}
