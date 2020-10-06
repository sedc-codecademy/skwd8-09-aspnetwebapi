using Models;
using Models.Dto;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class NotesRepository : INotesRepository
    {
        public Note Add(NoteDtoAdd model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Note Edit(NoteDtoEdit model)
        {
            throw new NotImplementedException();
        }

        public Note Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NoteDtoGetAll> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
