using Models.Dto;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface INoteService
    {
        IEnumerable<NoteGetAllDto> GetAll();
        IEnumerable<NoteGetAllDto> GetAll(Guid userId);
        Note GetById(Guid noteId,Guid userId);
        Note Add(NoteAddDto note);
        Note Edit(NoteEditDto note);
        bool Delete(Guid noteId,Guid userId);
    }
}
