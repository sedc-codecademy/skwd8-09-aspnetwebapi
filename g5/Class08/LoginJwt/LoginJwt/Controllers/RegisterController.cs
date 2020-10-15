using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ViewModels;

namespace LoginJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            _userService.Register(model);
            return StatusCode(StatusCodes.Status201Created, "Successfully registered");
        }
    }
}
