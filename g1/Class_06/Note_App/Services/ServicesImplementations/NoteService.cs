using Data.Interfaces;
using Domain_Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.ServicesImplementations
{
    public class NoteService : INoteService
    {
        private IRepository<Note> _noteRepo;
        public NoteService(IRepository<Note> noteRepo)
        {
            _noteRepo = noteRepo;
        }
        public void AddNote(Note note)
        {
            _noteRepo.Insert(note);
        }

        public void DeleteNote(int id)
        {
            _noteRepo.Remove(id);
        }

        public List<Note> GetAllNotes()
        {
            return _noteRepo.GetAll().ToList();
        }

        public Note GetNoteById(int id)
        {
            return _noteRepo.GetById(id);
        }

        public void UpdateNote(Note note)
        {
            _noteRepo.Update(note);
        }
    }
}
