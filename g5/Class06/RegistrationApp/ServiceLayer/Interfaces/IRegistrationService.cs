using System.Collections.Generic;
using ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IRegistrationService
    {
        List<RegistrationViewModel> GetAll();
        RegistrationViewModel GetById(int id);
        void Add(RegistrationViewModel model);
        void Update(RegistrationViewModel model);
        void Delete(int id);
    }
}
