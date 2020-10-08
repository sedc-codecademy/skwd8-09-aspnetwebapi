using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ViewModels;

namespace RegistrationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        public ActionResult<List<RegistrationViewModel>> GetAll()
        {
            return _registrationService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<RegistrationViewModel> GetById(int id)
        {
            return _registrationService.GetById(id);
        }

        [HttpPost]
        public IActionResult Add(RegistrationViewModel model)
        {
            _registrationService.Add(model);
            return StatusCode(StatusCodes.Status201Created, "Successfully registered");
        }

        [HttpPut]
        public IActionResult Update(RegistrationViewModel model)
        {
            _registrationService.Update(model);
            return StatusCode(StatusCodes.Status200OK, "Registration updated");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _registrationService.Delete(id);
            return StatusCode(StatusCodes.Status200OK, "Registration deleted");
        }
    }
}
