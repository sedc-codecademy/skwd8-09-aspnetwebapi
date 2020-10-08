using Models;
using Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface INotesRepository
    {
        IEnumerable<NoteDtoGetAll> GetAll();
        Note Get(Guid id);
        Note Add(NoteDtoAdd model);
        Note Edit(NoteDtoEdit model);
        bool Delete(Guid id);
    }
}
