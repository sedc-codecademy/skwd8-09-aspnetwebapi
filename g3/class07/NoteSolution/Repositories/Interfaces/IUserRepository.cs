using Models.Dto;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        void Add(User user);

        bool Edit(EditUserDto user);

        User GetById(Guid id);

        bool Delete(Guid id);
    }
}
