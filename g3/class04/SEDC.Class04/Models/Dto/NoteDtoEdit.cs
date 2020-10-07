using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Dto
{
    public class NoteDtoEdit
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
