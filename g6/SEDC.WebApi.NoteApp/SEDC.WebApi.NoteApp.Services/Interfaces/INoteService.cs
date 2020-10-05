using SEDC.WebApi.NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.WebApi.NoteApp.Services.Interfaces
{
    public interface INoteService
    {
        IEnumerable<NoteDto> GetUserNotes(int userId);
        NoteDto GetNote(int id, int userId);
        void AddNote(NoteDto request);
        void DeleteNote(int id, int userId);
    }
}
