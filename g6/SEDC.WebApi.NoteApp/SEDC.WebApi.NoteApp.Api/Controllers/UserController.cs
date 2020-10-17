using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.NoteApp.Models;
using SEDC.WebApi.NoteApp.Services.Exceptions;
using SEDC.WebApi.NoteApp.Services.Interfaces;
using Serilog;
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

                Log.Information($"USER: {response.Username} has logged in");
                //Debug.WriteLine($"{response.Id} has been loged in");
                return Ok(response);
            }
            catch(UserException ex)
            {
                Log.Error($"USER: {ex.UserId}.{ex.Name}: {ex.Message}");
                //Debug.WriteLine($"USER: {ex.UserId}.{ex.Name} {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error("USER: {message}", ex.Message);
                //Debug.WriteLine(ex.Message);
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

                Log.Information("USER: {username} has registered", request.Username);
                //Debug.WriteLine($"User registered with {request.Username}");
                return Ok("Success");
            }
            catch(UserException ex)
            {
                Log.Error($"USER: {ex.UserId}.{ex.Name}: {ex.Message}");
                //Debug.WriteLine($"User {ex.UserId}.{ex.Name}: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error($"USER: {ex.Message}");
                //Debug.WriteLine($"Unknown error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
