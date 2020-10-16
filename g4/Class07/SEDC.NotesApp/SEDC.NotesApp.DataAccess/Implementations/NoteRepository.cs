using SEDC.NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SEDC.NotesApp.DataAccess.Interfaces;
using SEDC.NotesApp.Domain;

namespace SEDC.NotesApp.DataAccess.Implementations
{
    public class NoteRepository :INoteRepository
    {
        private NotesAppDbContext _notesAppDbContext;

        public NoteRepository(NotesAppDbContext notesAppDbContext)
        {
            _notesAppDbContext = notesAppDbContext;
        }
        public List<Note> GetAll()
        {
            return _notesAppDbContext
                .Notes
                .Include(x => x.User) //join with table users
                .ToList();
        }

        public Note GetById(int id)
        {
            return _notesAppDbContext
                .Notes
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Add(Note entity)
        {
            _notesAppDbContext.Notes.Add(entity);
            _notesAppDbContext.SaveChanges(); //request to DB
        }

        public void Delete(Note entity)
        {
            _notesAppDbContext.Notes.Remove(entity);
            _notesAppDbContext.SaveChanges();
        }

        public void Update(Note entity)
        {
            _notesAppDbContext.Notes.Update(entity);
            _notesAppDbContext.SaveChanges();
        }

        public List<Note> GetNotesByUserId(int userId)
        {
            return _notesAppDbContext.Notes
                .Include(x => x.User)
                .Where(x => x.UserId == userId).ToList();
        }
    }
}
