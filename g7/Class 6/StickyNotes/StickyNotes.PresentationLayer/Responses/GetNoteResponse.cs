using System;
using System.Collections.Generic;
using System.Text;

namespace StickyNotes.PresentationLayer.Responses
{
    public class GetNoteResponse
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int? Color { get; set; }
        public string NameOfUser { get; set; }
    }
}
