using System;
using System.Collections.Generic;

namespace StickyNotes.DataAccess.Domain
{
    public partial class Note
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int? Color { get; set; }
        public int UserFk { get; set; }

        public virtual User UserFkNavigation { get; set; }
    }
}
