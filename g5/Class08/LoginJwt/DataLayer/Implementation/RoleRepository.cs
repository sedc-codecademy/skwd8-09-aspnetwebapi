using System.Collections.Generic;
using DomainModels;

namespace DataLayer.Implementation
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly LoginContext _context;

        public RoleRepository(LoginContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles;
        }

        public Role GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Role entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Role entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
