using System.Collections.Generic;

namespace NotesApi.Models
{
    public class Note
    {
        public string Text { get; set; }
        public List<Tag> Tags { get; set; }

        public Note()
        {
            
        }

        public Note(string text, List<Tag> tags)
        {
            Text = text;
            Tags = tags;
        }
    }
}
