using System;
using System.Collections.Generic;
using System.Text;
using SEDC.NotesApp.Domain.Models;

namespace SEDC.NotesApp.DataAccess.Interfaces
{
    public interface INoteRepository : IRepository<Note>
    {
        List<Note> GetNotesByUserId(int userId);
    }
}
