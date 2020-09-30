namespace NotesApi.Models
{
    public class Tag
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public Tag()
        {
            
        }

        public Tag(string name, string color)
        {
            Name = name;
            Color = color;
        }
    }
}
