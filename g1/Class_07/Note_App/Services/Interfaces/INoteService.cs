using Domain_Models.Models;
using DTO_Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface INoteService
    {
        List<NoteModel> GetAllNotes();
        NoteModel GetNoteById(int id);
        void AddNote(NoteModel note);
        void UpdateNote(NoteModel note);
        void DeleteNote(int id);
    }
}
