using Models.Dto;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User GetById(Guid id);
        User GetByUsername(string username);
        User Add(User model);
        User Edit(User model);
        int Delete(Guid id);
    }
}
