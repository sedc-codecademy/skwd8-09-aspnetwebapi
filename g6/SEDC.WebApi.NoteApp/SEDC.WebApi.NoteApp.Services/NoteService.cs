using SEDC.WebApi.NoteApp.DataAccess;
using SEDC.WebApi.NoteApp.DataModel;
using SEDC.WebApi.NoteApp.Models;
using SEDC.WebApi.NoteApp.Services.Exceptions;
using SEDC.WebApi.NoteApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SEDC.WebApi.NoteApp.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Note> _noteRepository;

        public NoteService(IRepository<User> userRepository,
            IRepository<Note> noteRepository)
        {
            this._userRepository = userRepository;
            this._noteRepository = noteRepository;
        }

        public void AddNote(NoteDto request)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Id == request.UserId);

            if(user == null)
            {
                throw new NoteException("User does not exists");
            }

            if (string.IsNullOrWhiteSpace(request.Text))
            {
                throw new NoteException("Text is required");
            }

            if (string.IsNullOrWhiteSpace(request.Color))
            {
                throw new NoteException("Color is required");
            }

            if (request.Tag == 0 || (int)request.Tag > 5)
            {
                throw new NoteException("Tag is required and should be betwen 1 and 5");
            }

            var note = new Note
            {
                Text = request.Text,
                Color = request.Color,
                UserId = request.UserId,
                Tag = (int)request.Tag
            };

            // TODO: create link to note

            _noteRepository.Insert(note);
        }

        public void DeleteNote(int id, int userId)
        {
            throw new System.NotImplementedException();
        }

        public NoteDto GetNote(int id, int userId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<NoteDto> GetUserNotes(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
