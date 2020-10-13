using Models;
using Models.Dto;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class NotesService : INotesService
    {
        private INotesRepository _notesRepository;

        public NotesService(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public Note Add(NoteDtoAdd model) => _notesRepository.Add(model);

        public bool Delete(Guid id)
        {
            var noteItem = _notesRepository.Get(id);

            if (noteItem == null)
            {
                return false;
            }

            _notesRepository.Delete(noteItem.Id);

            return true;
        }

        public Note Edit(NoteDtoEdit model) => _notesRepository.Edit(model);

        public Note Get(Guid id) => _notesRepository.Get(id);

        public IEnumerable<NoteDtoGetAll> GetAll() => _notesRepository.GetAll();
    }
}
