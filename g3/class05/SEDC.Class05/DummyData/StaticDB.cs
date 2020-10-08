using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DummyData
{
    public static class StaticDB
    {
        public static List<Note> Notes { get; set; }

        static StaticDB()
        {
            Notes = new List<Note>
            {
                new Note
                {
                    Id = Guid.NewGuid(),
                    Title = "Go to dentist",
                    Description = "dont forget kniska",
                    Created = new DateTime(2020, 9, 27),
                    DueDate = new DateTime(2020, 10, 4)
                },

                new Note
                {
                    Id = Guid.NewGuid(),
                    Title = "Buy bike equipment",
                    Description = "seat, oil",
                    Created = new DateTime(2020, 9, 23),
                    DueDate = new DateTime(2020, 10, 8)
                },

                new Note
                {
                    Id = Guid.NewGuid(),
                    Title = "Buy grosries",
                    Description = "",
                    Created = new DateTime(2020, 9, 12),
                    DueDate = new DateTime(2020, 10, 2)
                },

                new Note
                {
                    Id = Guid.NewGuid(),
                    Title = "do the homework",
                    Description = "class 2",
                    Created = new DateTime(2020, 8, 27),
                    DueDate = new DateTime(2020, 11, 6)
                }
            };
        }
    }
}
