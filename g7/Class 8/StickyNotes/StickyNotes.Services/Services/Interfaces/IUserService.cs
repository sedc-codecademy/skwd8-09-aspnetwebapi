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
        List<GetUserResponse> GetUsersWithMostNotes();
        void CreateUser(GetUserResponse userResponse);
        void UpdateUser(GetUserResponse userResponse);
        void DeleteUser(GetUserResponse userResponse);
    }
}
