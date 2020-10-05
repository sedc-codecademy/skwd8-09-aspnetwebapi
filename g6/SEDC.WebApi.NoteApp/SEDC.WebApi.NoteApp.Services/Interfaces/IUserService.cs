using SEDC.WebApi.NoteApp.Models;

namespace SEDC.WebApi.NoteApp.Services.Interfaces
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        void Register(RegisterModel request);
    }
}
