using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Dto
{
    public class NoteGetAllDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid UserId { get; set; }
    }
}
