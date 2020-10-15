using Domain_Models.Models;
using DTO_Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mappings
{
    public static class NoteMapper
    {
        public static NoteModel NoteToNoteModel(Note note)
        {
            return new NoteModel()
            {
                Id = note.Id,
                Text = note.Text,
                Color = note.Color,
                Tag = note.Tag,
                UserId = note.UserId
            };
        }
        public static Note NoteModelToNote(NoteModel note)
        {
            return new Note()
            {
                Id = note.Id,
                Text = note.Text,
                Color = note.Color,
                Tag = note.Tag,
                UserId = note.UserId
            };
        }
        public static List<NoteModel> NotesToNotesModels(List<Note> notes)
        {
            return notes.Select(note => new NoteModel()
            {
                Id = note.Id,
                Text = note.Text,
                Color = note.Color,
                Tag = note.Tag,
                UserId = note.UserId
            }).ToList();
        }
        public static List<Note> NotesModelsToNotes(List<NoteModel> notes)
        {
            return notes.Select(note => new Note()
            {
                Id = note.Id,
                Text = note.Text,
                Color = note.Color,
                Tag = note.Tag,
                UserId = note.UserId
            }).ToList();
        }
    }
}
