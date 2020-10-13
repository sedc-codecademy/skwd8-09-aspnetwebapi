using System;
using System.Collections.Generic;
using System.Text;
using SEDC.NotesApp.Models;

namespace SEDC.NotesApp.Services.Interfaces
{
    public interface INoteService
    {
        List<NoteModel> GetAllNotes();
        NoteModel GetNoteById(int id);
        void AddNote(NoteModel noteModel);
        void UpdateNote(NoteModel noteModel);
        void DeleteNote(int id);
    }
}
