using System.Collections.Generic;
using NotesApi.Models;

namespace NotesApi
{
    public static class StaticDb
    {
        public static List<string> Notes = new List<string>()
        {
            "Go to gym",
            "Do the dishes",
            "Do the homework"
        };

        public static List<Tag> Tags = new List<Tag>()
        {
            new Tag("sport", "blue"),
            new Tag("work", "red"),
            new Tag("education", "green")
        };

        public static List<Note> NoteTags = new List<Note>()
        {
            new Note("Go to gym", new List<Tag>() {Tags[0]}),
            new Note("Go to work", new List<Tag>() {Tags[1], Tags[2]}),
            new Note("Go at SEDC", new List<Tag>() {Tags[2]})
        };
    }
}
