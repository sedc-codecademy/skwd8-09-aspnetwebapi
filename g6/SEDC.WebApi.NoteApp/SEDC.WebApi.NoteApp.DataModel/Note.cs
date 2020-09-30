using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.WebApi.NoteApp.DataModel
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public int Tag { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
