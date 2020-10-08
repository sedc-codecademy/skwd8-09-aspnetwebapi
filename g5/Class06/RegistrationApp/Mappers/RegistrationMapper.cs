using System;
using DomainModels;
using ViewModels;

namespace Mappers
{
    public static class RegistrationMapper
    {
        public static RegistrationViewModel ToViewModel(this Registration registration)
        {
            return new RegistrationViewModel
            {
                Id = registration.Id,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Company = registration.Company,
                Email = registration.Email
            };
        }
    }
}
