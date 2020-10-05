using Microsoft.EntityFrameworkCore;
using StickyNotes.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StickyNotes.DataAccess.Repositories
{
    public class NoteRepository : IRepository<Note>
    {
        private readonly DbContext _context;

        public NoteRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(Note entity)
        {
            _context.Add(entity);
        }

        public void Delete(Note entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<Note> GetAll()
        {
            IEnumerable<Note> notes = _context.Set<Note>()
                .Include(n => n.UserFkNavigation);

            return notes;
        }

        public Note GetById(int id)
        {
            Note note = _context.Set<Note>()
                .Include(n => n.UserFkNavigation)
                .Single(n => n.Id == id);

            return note;
        }

        public void Update(Note entity)
        {
            _context.Update(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
