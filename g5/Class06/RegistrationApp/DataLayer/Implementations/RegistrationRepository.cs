using System;
using System.Collections.Generic;
using System.Linq;
using DomainModels;

namespace DataLayer.Implementations
{
    public class RegistrationRepository : IRepository<Registration>
    {
        private readonly RegistrationAppContext _dbContext;

        public RegistrationRepository(RegistrationAppContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Registration> GetAll()
        {
            return _dbContext.Registrations;
        }

        public Registration GetById(int id)
        {
            var registration = _dbContext.Registrations.FirstOrDefault(x => x.Id == id);

            if (registration == null)
            {
                throw new ApplicationException("The registration does not exist");
            }

            return registration;
        }

        public void Insert(Registration entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Registration entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var registration = GetById(id);
            _dbContext.Remove(registration);
            _dbContext.SaveChanges();
        }
    }
}
