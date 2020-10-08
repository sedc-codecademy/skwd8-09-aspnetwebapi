using SEDC.NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NoteApp.Services
{
    public interface IUserService
    {
        void Register(RegisterModel model);
    }
}
