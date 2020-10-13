using Models.Dto;
using Models.Entity;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    // All hard and complex logic should be placed in here, services are used to do the hard work
    // Note: rethrowing execptions will cause an HTTP Status Code: 500 in the controllers
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository; // INoteRepository will be resolved to an object of NoteRepository

        public NoteService(INoteRepository noteRepository) // The dependency injection container will pass an object of NoteRepository, this is configured in Startup.cs
        {
            _noteRepository = noteRepository;
        }

        public IEnumerable<NoteGetAllDto> GetAll()
        {
            try
            {
                // .GetAll returns IQueryable so that we can continue to contruct the query in the services
                return _noteRepository.GetAll()
                                    .Select(note => new NoteGetAllDto
                                    {
                                        Id = note.Id,
                                        Title = note.Title,
                                        DueDate = note.DueDate,
                                        UserId = note.UserId
                                    })
                                    .AsEnumerable(); // The moment this method is called, the query is executed
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<NoteGetAllDto> GetAll(Guid userId)
        {
            try
            {
                // .GetAll returns IQueryable so that we can continue to contruct the query in the services
                return _noteRepository.GetAll()
                                        .Where(note => note.UserId == userId)
                                        .Select(note => new NoteGetAllDto
                                        {
                                            Id = note.Id,
                                            Title = note.Title,
                                            DueDate = note.DueDate,
                                            UserId = note.UserId
                                        })
                                        .AsEnumerable(); // The moment this method is called, the query is executed
            }
            catch (Exception ex)
            {
                throw ex;
            }                       
        }

        public Note GetById(Guid noteId)
        {
            try
            {
                return _noteRepository.GetById(noteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Note Add(NoteAddDto noteDto)
        {
            try
            {
                Note note = new Note
                {
                    Id = Guid.NewGuid(),
                    Title = noteDto.Title,
                    Description = noteDto.Description,
                    CreatedDate = DateTime.Now,
                    DueDate = noteDto.DueDate,
                    UserId = noteDto.UserId,
                    ModifiedDate = null
                };

                return _noteRepository.Add(note);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Note Edit(NoteEditDto noteDto)
        {
            try
            {
                noteDto.ModifiedDate = DateTime.Now;
                return _noteRepository.Edit(noteDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(Guid noteId)
        {
            try
            {
                // .SaveChanges() method returns the state of the save operation: -1 - Failed, 0 - No changes, 1 - Success
                int saveResult = _noteRepository.Delete(noteId);

                if (saveResult < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
