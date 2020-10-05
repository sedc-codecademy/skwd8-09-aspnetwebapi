using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note_App.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
