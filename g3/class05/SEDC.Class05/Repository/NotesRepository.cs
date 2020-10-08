using DummyData;
using Models;
using Models.Dto;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class NotesRepository : INotesRepository
    {
        private DataDbContext _dataDbContext;

        public NotesRepository(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

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
            ///var result = _dataDbContext.Notes.Select(x=> new NoteDtoGetAll { })

            throw new NotImplementedException();
        }
    }
}
