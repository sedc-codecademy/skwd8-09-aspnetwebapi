using System;
using System.Collections.Generic;

namespace Class04.EntityFramework.DataModels.CreatedFromDb
{
    public partial class Notes
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public int Tag { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }
    }
}
