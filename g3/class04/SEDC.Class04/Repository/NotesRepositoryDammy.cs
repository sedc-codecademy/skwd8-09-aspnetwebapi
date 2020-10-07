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
    public class NotesRepositoryDammy : INotesRepository
    {
        public IEnumerable<NoteDtoGetAll> GetAll()
        {
            try
            {
                return StaticDB.Notes.Select(n => new NoteDtoGetAll
                {
                    Id = n.Id,
                    Title = n.Title,
                    DueDate = n.DueDate
                }).ToList();
            }
            catch (Exception)
            {
                return new List<NoteDtoGetAll>();
            }
        }

        public Note Get(Guid id)
        {
            try
            {
                return StaticDB.Notes.FirstOrDefault(n => n.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Note Add(NoteDtoAdd model)
        {
            try
            {
                Note note = new Note
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    Title = model.Title,
                    Description = model.Description,
                    DueDate = model.DueDate
                };

                StaticDB.Notes.Add(note);
                return note;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public Note Edit(NoteDtoEdit model)
        {
            Note note = StaticDB.Notes.FirstOrDefault(n => n.Id == model.Id);

            try
            {
                note.Title = !string.IsNullOrWhiteSpace(model.Title) ? model.Title : note.Title;
                note.Description = !string.IsNullOrWhiteSpace(model.Description) ? model.Description : note.Description;
                note.DueDate = !(model.DueDate == null) ? model.DueDate : note.DueDate;
                return note;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Guid id)
        {
            Note note = StaticDB.Notes.FirstOrDefault(n => n.Id == id);

            try
            {
                StaticDB.Notes.Remove(note);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
