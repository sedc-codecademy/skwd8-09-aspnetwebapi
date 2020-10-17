using System;
using System.Collections.Generic;
using System.Text;
using SEDC.NotesApp.Models;

namespace SEDC.NotesApp.Services.Interfaces
{
    public interface IUserService
    {
        void RegisterUser(RegisterModel registerModel);
        string LoginUser(LoginModel loginModel);
    }
}
