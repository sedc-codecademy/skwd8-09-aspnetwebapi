using ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterViewModel model);
        UserViewModel Login(LoginViewModel model);
    }
}
