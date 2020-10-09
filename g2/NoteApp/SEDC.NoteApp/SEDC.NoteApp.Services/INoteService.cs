using SEDC.NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NoteApp.Services
{
    public interface INoteService
    {
        IEnumerable<NoteModel> GetUserNotes(int userId);
        NoteModel GetNote(int id, int userId);
        void AddNote(NoteModel note);
        void DeleteNote(int id, int userId);

    }
}
