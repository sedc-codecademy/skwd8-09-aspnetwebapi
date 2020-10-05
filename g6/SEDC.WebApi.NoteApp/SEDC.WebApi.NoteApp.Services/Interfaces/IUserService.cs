using SEDC.WebApi.NoteApp.Models;

namespace SEDC.WebApi.NoteApp.Services.Interfaces
{
    public interface IUserService
    {
        void Authenticate(string username, string password);
        void Register(RegisterModel request);
    }
}
