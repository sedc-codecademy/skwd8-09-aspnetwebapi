namespace StickyNotes.WebAPI.Entities
{
    public abstract class BaseNoteEntity
    {
        public int ID { get; set; }
        private static int _id = 1;
        public BaseNoteEntity()
        {
            ID = _id++;
        }
    }
}
