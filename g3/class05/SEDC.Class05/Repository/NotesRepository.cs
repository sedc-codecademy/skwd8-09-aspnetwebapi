using DummyData;
using Models;
using Models.Dto;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class NotesRepository : INotesRepository
    {
        private DataDbContext _dataDbContext;

        public NotesRepository(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public Note Add(NoteDtoAdd model)
        {
            var noteToAdd = new Note
            {
                Title = model.Title,
                Description = model.Description,
                Created = DateTime.Now,
                DueDate = model.DueDate
            };

            _dataDbContext.Notes.Add(noteToAdd);
            _dataDbContext.SaveChanges();

            return noteToAdd;
        }

        public bool Delete(Guid id)
        {
            var result = _dataDbContext.Notes.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return false;
            }


            _dataDbContext.Notes.Remove(result);
            _dataDbContext.SaveChanges();

            return true;
        }

        public Note Edit(NoteDtoEdit model)
        {
            var result = _dataDbContext.Notes.FirstOrDefault(x => x.Id == model.Id);

            if (result == null)
            {
                return null;
            }

            result.Title = model.Title;
            result.Description = model.Description;
            result.DueDate = model.DueDate;

            _dataDbContext.Notes.Update(result);
            _dataDbContext.SaveChanges();

            return result;
        }

        public Note Get(Guid id)
        {
            var result = _dataDbContext.Notes.Where(x => x.Id == id).FirstOrDefault();

            return result;
        }

        public IEnumerable<NoteDtoGetAll> GetAll()
        {
            var result = _dataDbContext.Notes
                .Select(x => new NoteDtoGetAll
                {
                    Id = x.Id,
                    DueDate = x.DueDate,
                    Title = x.Title
                }).AsEnumerable();

            return result;
        }
    }
}
