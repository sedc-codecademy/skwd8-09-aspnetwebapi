using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DomainModels;
using Mappers;
using ServiceLayer.Interfaces;
using ViewModels;

namespace ServiceLayer.Implementations
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRepository<Registration> _registrationRepository;

        public RegistrationService(IRepository<Registration> registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public List<RegistrationViewModel> GetAll()
        {
            return _registrationRepository.GetAll().Select(x => x.ToViewModel()).ToList();
        }

        public RegistrationViewModel GetById(int id)
        {
            var registration = _registrationRepository.GetById(id);
            return registration.ToViewModel();
        }

        public void Add(RegistrationViewModel model)
        {
            if (_registrationRepository.GetAll().Any(x =>
                string.Equals(x.Email, model.Email, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ApplicationException($"Registration for the email {model.Email} already exists");
            }

            var registration = new Registration
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Company = model.Company
            };

            _registrationRepository.Insert(registration);
        }

        public void Update(RegistrationViewModel model)
        {
            var registration = _registrationRepository.GetById(model.Id);

            if (registration == null)
            {
                throw new ApplicationException($"Registration with id {model.Id} does not exist");
            }

            if (_registrationRepository.GetAll().Any(x =>
                string.Equals(x.Email, model.Email, StringComparison.InvariantCultureIgnoreCase)
                && x.Id != model.Id))
            {
                throw new ApplicationException($"Registration for the email {model.Email} already exists");
            }

            registration.FirstName = model.FirstName;
            registration.LastName = model.LastName;
            registration.Email = model.Email;
            registration.Company = model.Company;

            _registrationRepository.Update(registration);
        }

        public void Delete(int id)
        {
            _registrationRepository.Delete(id);
        }
    }
}
