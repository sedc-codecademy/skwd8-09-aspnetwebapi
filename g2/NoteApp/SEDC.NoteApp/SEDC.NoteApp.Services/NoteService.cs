using SEDC.NoteApp.DataAccess;
using SEDC.NoteApp.DataModels;
using SEDC.NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.NoteApp.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<NoteDTO> _noteRepository; 
        private readonly IRepository<UserDTO> _userRepository;

        public NoteService(IRepository<NoteDTO> noteRepository, IRepository<UserDTO> userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }

        public void AddNote(NoteModel note)
        {
            if (string.IsNullOrEmpty(note.Text))
                throw new Exception("Text field is required");

            var noteDTO = new NoteDTO
            {
                Text = note.Text,
                Color = note.Color,
                Tag = (int)note.Tag,
                UserId = note.UserId
            };
            _noteRepository.Add(noteDTO);
        }

        public void DeleteNote(int id, int userId)
        {
            var note = _noteRepository.GetAll()
                                      .FirstOrDefault(x => x.Id == id && x.UserId == userId);
            if (note == null)
                throw new Exception("Note not found");

            _noteRepository.Delete(note);
        }

        public NoteModel GetNote(int id, int userId)
        {
            var note = _noteRepository.GetAll()
                                      .FirstOrDefault(x => x.Id == id && x.UserId == userId);
            if (note == null)
                throw new Exception("Note not found");

            var noteModel = new NoteModel
            {
                Id = note.Id,
                Text = note.Text,
                Color = note.Color,
                UserId = note.UserId,
                Tag = (TagType)note.Tag
            };
            return noteModel;
        }

        public IEnumerable<NoteModel> GetUserNotes(int userId)
        {
            return _noteRepository.GetAll()
                                  .Where(x => x.UserId == userId)
                                  .Select(x =>
                                  new NoteModel
                                  {
                                      Id = x.Id,
                                      Text = x.Text,
                                      Tag = (TagType)x.Tag,
                                      Color = x.Color,
                                      UserId = x.UserId
                                  });
        }
    }
}
