using Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterUserDto user);
        LoggedUserDto Authenticate(string user,string password);
    }
}
