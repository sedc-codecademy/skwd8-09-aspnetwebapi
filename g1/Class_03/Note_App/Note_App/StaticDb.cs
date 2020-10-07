using Note_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note_App
{

    //hhtp:// localhost:5000/api/notes?firstName=Goce&lastName=Kabov&age=35

    public static class StaticDb
    {
        public static List<string> GetSimpleNotes = new List<string>()
        {
            "Go to school",
            "Go to gym",
            "Do the dishes"
        };

        public static List<Note> AdvanceNotes = new List<Note>()
        {
            new Note()
            {
                Id = 1,
                Text = "Do Homework",
                Color = "green",
                Tags = new List<Tag>()
                {
                    new Tag()
                    {
                        Text = "Obligatory",
                        Color = "red"
                    },
                    new Tag()
                    {
                        Text = "SEDC",
                        Color = "green"
                    }
                }
            },
            new Note()
            {
                Id = 2,
                Text = "Go to gym",
                Color = "green",
                Tags = new List<Tag>()
                {
                    new Tag()
                    {
                        Text = "Obligatory",
                        Color = "red"
                    },
                    new Tag()
                    {
                        Text = "SEDC",
                        Color = "green"
                    }
                }
            }
        };
    }
}
