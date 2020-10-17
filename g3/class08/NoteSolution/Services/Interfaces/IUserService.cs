using Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserService
    {
        UserWithTokenDto Authenticate(UserSignInDto model);
        void Register(UserRegisterDto model);
    }
}
