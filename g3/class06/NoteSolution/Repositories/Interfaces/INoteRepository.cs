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
        Note GetById(Guid noteId);
        Note Add(Note note);
        Note Edit(NoteEditDto noteDto);
        int Delete(Guid noteId);
    }
}
