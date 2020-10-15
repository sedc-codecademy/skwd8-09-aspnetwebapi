using System.Collections.Generic;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Implementation
{
    public class UserRepository : IRepository<User>
    {
        private readonly LoginContext _loginContext;

        public UserRepository(LoginContext loginContext)
        {
            _loginContext = loginContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _loginContext.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role);
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(User entity)
        {
            _loginContext.Users.Add(entity);
            _loginContext.SaveChanges();
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
