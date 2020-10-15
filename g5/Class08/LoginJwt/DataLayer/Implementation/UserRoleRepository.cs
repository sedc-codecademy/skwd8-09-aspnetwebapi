using System.Collections.Generic;
using DomainModels;

namespace DataLayer.Implementation
{
    public class UserRoleRepository : IRepository<UserRole>
    {
        private readonly LoginContext _context;

        public UserRoleRepository(LoginContext context)
        {
            _context = context;
        }

        public IEnumerable<UserRole> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public UserRole GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(UserRole entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(UserRole entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
