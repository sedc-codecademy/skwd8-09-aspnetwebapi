using System;
using System.Collections.Generic;
using System.Text;
using SEDC.NotesApp.DataAccess;
using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Mappers;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.Exceptions;

namespace SEDC.NotesApp.Services.Implementations
{
    public class NoteService : INoteService
    {
        private IRepository<Note> _noteRepository;
        private IRepository<User> _userRepository;

        public NoteService(IRepository<Note> noteRepository, IRepository<User> userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }

        public List<NoteModel> GetAllNotes()
        {
            List<Note> notesDb = _noteRepository.GetAll();
            List<NoteModel> noteModels = new List<NoteModel>();
            foreach (Note note in notesDb)
            {
                noteModels.Add(note.ToNoteModel());
            }

            return noteModels;
        }

        public NoteModel GetNoteById(int id)
        {
            Note noteDb = _noteRepository.GetById(id);
            if (noteDb == null)
            {
                //log
                throw new NotFoundException($"Note with id {id} was not found!");
                //throw new NotFoundException(id);
            }

            return noteDb.ToNoteModel();
        }

        public void AddNote(NoteModel noteModel)
        {
            User userDb = ValidateNoteModel(noteModel);

            Note noteForDb = noteModel.ToNote();
            noteForDb.User = userDb;
            _noteRepository.Add(noteForDb);
        }

        public void UpdateNote(NoteModel noteModel)
        {
            Note noteDb = _noteRepository.GetById(noteModel.Id);
            if (noteDb == null)
            {
                throw new NotFoundException(noteModel.Id);
            }
            User userDb = ValidateNoteModel(noteModel);

            noteDb.Text = noteModel.Text;
            noteDb.Color = noteModel.Color;
            noteDb.Tag = noteModel.Tag;
            noteDb.UserId = noteModel.UserId;
            noteDb.User = userDb;
            _noteRepository.Update(noteDb);
        }

        public void DeleteNote(int id)
        {
            Note noteDb = _noteRepository.GetById(id);
            if (noteDb == null)
            {
                throw new NotFoundException(id);
            }
            _noteRepository.Delete(noteDb);
        }

        private User ValidateNoteModel(NoteModel noteModel)
        {
            User userDb = _userRepository.GetById(noteModel.UserId);
            if (userDb == null)
            {
                //log
                throw new NoteException($"The user with id {noteModel.UserId} was not found!");
            }

            //if (noteModel.Id != 0)
            //{
            //    throw new NoteException("Id must not be set!");
            //}
            if (string.IsNullOrEmpty(noteModel.Text))
            {
                throw new NoteException("The property Text for note is required");
            }
            if (noteModel.Text.Length > 100)
            {
                throw new NoteException("The property Text can not contain more than 100 characters");
            }
            if (!string.IsNullOrEmpty(noteModel.Color) && noteModel.Color.Length > 30)
            {
                throw new NoteException("The property Color can not contain more than 30 characters");
            }

            return userDb;
        }
    }
}
