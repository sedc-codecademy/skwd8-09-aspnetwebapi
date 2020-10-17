using StickyNotes.API.Models;
using StickyNotes.PresentationLayer.Responses;
using System.Collections;
using System.Collections.Generic;

namespace StickyNotes.Services.Services.Interfaces
{
    public interface IUserService
    {
        List<GetUserResponse> GetAllUsers();
        GetUserResponse GetById(int id);
        List<GetUserResponse> GetUserswithSameUsernameLength(int length);
        void CreateUser(GetUserResponse userResponse);
        void UpdateUser(GetUserResponse userResponse);
        void DeleteUser(GetUserResponse userResponse);

        GetUserResponse Authenticate(string username, string password);
        GetUserResponse Register(CreateUserRequest request);        
    }
}
