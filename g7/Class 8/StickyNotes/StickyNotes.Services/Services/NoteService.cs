using AutoMapper;
using StickyNotes.DataAccess.Domain;
using StickyNotes.DataAccess.Repositories;
using StickyNotes.PresentationLayer.Responses;
using StickyNotes.Services.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StickyNotes.Services.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IUserRepository _userRepository;

        public NoteService(IUserRepository userRepository,INoteRepository noteRepository)
        {
            _userRepository = userRepository;
            _noteRepository = noteRepository;
        }
        public List<GetNoteResponse> GetAllNotes()
        {
            var notes = _noteRepository.GetAll().ToList();
            var notesResponse = Mapper.Map<List<Note>, List<GetNoteResponse>>(notes);
            return notesResponse;
        }

        public List<GetNoteResponse> GetAllNotesByColor(int color)
        {
            throw new System.NotImplementedException();
        }

        public List<GetNoteResponse> GetAllNotesByUserId(int userId)
        {
            var user = _userRepository.GetById(userId);
            var notesResponse = Mapper.Map<List<Note>, List<GetNoteResponse>>(user.Notes.ToList());
            return notesResponse;
        }

        public GetNoteResponse GetNoteById(int noteId, int userId)
        {
            var note = _userRepository.GetById(userId).Notes.SingleOrDefault(n => n.Id == noteId);
            var noteResponse = Mapper.Map<Note, GetNoteResponse>(note);
            return noteResponse;
        }
        public void AddANoteToAUser(GetNoteResponse note, int userId)
        {
            var user = _userRepository.GetById(userId);
            var realNote = Mapper.Map<GetNoteResponse, Note>(note);
            user.Notes.Add(realNote);
            _userRepository.Update(user);
            _userRepository.Save();
        }
        public void UpdateNoteToAUser(GetNoteResponse note, int userid)
        {
            var noteToModify = _noteRepository.GetAll().Where(n => n.Title == note.Title).First();
            var user = _userRepository.GetById(userid);
            var realNote = Mapper.Map<GetNoteResponse, Note>(note);
             user.Notes.Remove(noteToModify);
            user.Notes.Add(realNote);
            _userRepository.Update(user);
            _userRepository.Save();
        }
        public void DeleteNoteFromAUser(int noteId, int userid)
        {
            var user = _userRepository.GetById(userid);
            var userNotes = user.Notes;
            var note = _noteRepository.GetById(noteId);
            userNotes.Remove(note);
            _userRepository.Update(user);
            _userRepository.Save();
        }
    }
}
