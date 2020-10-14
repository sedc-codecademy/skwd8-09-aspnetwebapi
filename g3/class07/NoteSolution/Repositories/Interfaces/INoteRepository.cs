using Models.Dto;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Interfaces
{
    public interface INoteRepository
    {
        IQueryable<Note> GetAll();
        Note GetById(Guid noteId, Guid userId);
        Note Add(Note note);
        Note Edit(NoteEditDto noteDto);
        bool Delete(Guid noteId, Guid userId);
    }
}
