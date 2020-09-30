using SEDC.WebApi.NoteApp.DataModel;
using System.Collections.Generic;

namespace SEDC.WebApi.NoteApp.DataAccess.EntityFramework
{
    public class NoteRepository : IRepository<Note>
    {
        private readonly NotesDbContext _context;

        public NoteRepository(NotesDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Note> GetAll()
        {
            return _context.Notes;
        }

        public void Insert(Note entity)
        {
            _context.Notes.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(Note entity)
        {
            _context.Notes.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Note entity)
        {
            _context.Notes.Update(entity);
            _context.SaveChanges();
        }
    }
}
