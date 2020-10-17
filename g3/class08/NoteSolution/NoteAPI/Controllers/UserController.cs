using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Services.Interfaces;

namespace NoteAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public UserWithTokenDto Authenticate([FromBody] UserSignInDto model)
        {
            return _userService.Authenticate(model);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public void Register([FromBody] UserRegisterDto model)
        {
            _userService.Register(model);
        }
    }
}
