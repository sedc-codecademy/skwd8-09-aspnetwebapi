using SEDC.NoteApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.NoteApp.DataAccess.EntityFramework
{
    public class NoteRepository : IRepository<NoteDTO>
    {
        private readonly NoteDbContext _db;
        public NoteRepository(NoteDbContext db)
        {
            _db = db;
        }

        public void Add(NoteDTO entity)
        {
            _db.Notes.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(NoteDTO entity)
        {
            _db.Notes.Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<NoteDTO> GetAll()
        {
            return _db.Notes;
        }

        public NoteDTO GetById(int id)
        {
            return _db.Notes.SingleOrDefault(x => x.Id == id);
        }

        public void Update(NoteDTO entity)
        {
            _db.Notes.Update(entity);
            _db.SaveChanges();
        }
    }
}
