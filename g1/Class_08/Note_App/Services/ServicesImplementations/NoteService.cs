using Data.Interfaces;
using Domain_Models.Models;
using DTO_Models.ApiModels;
using Mappings;
using Services.Exceptions;
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
        public void AddNote(NoteModel noteModel)
        {
            if (string.IsNullOrEmpty(noteModel.Text))
            {
                throw new NoteException(null, noteModel.UserId, "Text field is required!");
            }
            if (noteModel.Color.Count() < 3)
            {
                throw new NoteException(null, noteModel.UserId, "Color field can not have less than 3 characters!");
            }
            var note = NoteMapper.NoteModelToNote(noteModel);
            _noteRepo.Insert(note);
        }

        public void DeleteNote(int id)
        {
            var note = GetNoteById(id);
            if (note == null) throw new NoteException(id, 0, "Invalid note id!");
            _noteRepo.Remove(id);
        }

        public List<NoteModel> GetAllNotes()
        {
            var notes = _noteRepo.GetAll().ToList();
            return NoteMapper.NotesToNotesModels(notes);
        }

        public NoteModel GetNoteById(int id)
        {
            var note = _noteRepo.GetById(id);
            if (note == null) throw new NoteException(id, 0, "Invalid note id!");
            return NoteMapper.NoteToNoteModel(note);
        }

        public void UpdateNote(NoteModel noteModel)
        {
            var noteCheck = _noteRepo.GetById(noteModel.Id);
            if (noteCheck == null) throw new NoteException(noteModel.Id, 0,
                "No such note to be updated!");
            if (string.IsNullOrEmpty(noteModel.Text))
            {
                throw new NoteException(null, noteModel.UserId, "Text field is required!");
            }
            if (noteModel.Color.Count() < 3)
            {
                throw new NoteException(null, noteModel.UserId, "Color field can not have less than 3 characters!");
            }
            var note = NoteMapper.NoteModelToNote(noteModel);
            _noteRepo.Update(note);
        }
    }
}
