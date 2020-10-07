using Microsoft.EntityFrameworkCore.Migrations;
using SEDC.NotesApp.DataAccess;
using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Services.Implementations
{
    public class NoteService : INoteService
    {
        private IRepository<Note> _noteRepository;
        public NoteService(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public void AddNote(Note note)
        {
            _noteRepository.Add(note);
        }

        public void DeleteNote(int id)
        {
            _noteRepository.Delete(id);
        }

        public List<Note> GetAllNotes()
        {
            return _noteRepository.GetAll();
        }

        public Note GetNoteById(int id)
        {
            return _noteRepository.GetById(id);
        }

        public void UpdateNote(Note note)
        {
            _noteRepository.Update(note);
        }
    }
}
