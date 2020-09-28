namespace StickyNotes.WebAPI.Entities
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        private static int _id = 1;

        public BaseEntity()
        {
            ID = _id++;
        }
    }
}
