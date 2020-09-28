using System.Drawing;

namespace StickyNotes.WebAPI.Entities
{
    public class Note : BaseNoteEntity
    {
        public string Title { get; set; }
        public Color Color { get; set; }
        public string Text { get; set; }
    }
}
