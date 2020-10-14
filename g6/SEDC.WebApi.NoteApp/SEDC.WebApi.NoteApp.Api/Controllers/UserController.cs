using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.NoteApp.Models;
using SEDC.WebApi.NoteApp.Services.Exceptions;
using SEDC.WebApi.NoteApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.WebApi.NoteApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<UserModel> Authenticate(
            [FromBody]LoginModel request)
        {
            try
            {
                var response = _userService
                    .Authenticate(request.Username,
                    request.Password);

                Debug.WriteLine($"{response.Id} has been loged in");
                return Ok(response);
            }
            catch(UserException ex)
            {
                Debug.WriteLine($"USER: {ex.UserId}.{ex.Name} {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest("Something went wrong!");
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel request)
        {
            try
            {
                _userService.Register(request);
                Debug.WriteLine($"User registered with {request.Username}");
                return Ok("Success");
            }
            catch(UserException ex)
            {
                Debug.WriteLine($"User {ex.UserId}.{ex.Name}: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unknown error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
