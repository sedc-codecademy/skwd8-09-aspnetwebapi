using SEDC.NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NoteApp.Services
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        void Register(RegisterModel model);
    }
}
