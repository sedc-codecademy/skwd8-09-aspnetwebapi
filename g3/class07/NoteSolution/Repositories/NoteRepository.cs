using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models.Dto;
using Models.Entity;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NoteDbContext _context;

        public NoteRepository(NoteDbContext context)
        {
            _context = context;
        }

        public IQueryable<Note> GetAll()
        {
            return _context.Notes.AsQueryable(); // Returns IQueryable so that we can continue to build the query in the services
        }

        public Note GetById(Guid noteId, Guid userId)
        {
            return _context.Notes.SingleOrDefault(note => note.Id == noteId && note.UserId == userId);
        }

        public Note Add(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges(); // If we are making changes in the Database we need to save those changes

            return note;
        }

        public Note Edit(NoteEditDto noteDto)
        {
            // Edit is tricky
            // With .Find() we get the "reference" of the record from the db
            Note note = _context.Notes.FirstOrDefault(x => x.Id == noteDto.Id && x.UserId == noteDto.UserId);


            // And we make the wanted changes on that reference
            note.Title = noteDto.Title;
            note.Description = noteDto.Description;
            note.DueDate = noteDto.DueDate;
            note.ModifiedDate = noteDto.ModifiedDate;
            _context.Notes.Update(note);
            _context.SaveChanges(); // And we should not forget to save those changes in the Database

            return note;
        }

        public bool Delete(Guid noteId, Guid userId)
        {
            Note note = _context.Notes.FirstOrDefault(x => x.Id == noteId && x.UserId == userId);

            if (note == null)
            {
                return false;
            }

            _context.Notes.Remove(note);
            _context.SaveChanges();

            return false;
        }
    }
}
