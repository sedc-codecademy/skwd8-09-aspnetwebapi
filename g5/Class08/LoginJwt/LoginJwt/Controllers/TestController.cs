using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Test()
        {
            return StatusCode(StatusCodes.Status200OK, "You are user");
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Test(int id)
        {
            return StatusCode(StatusCodes.Status200OK, "You are admin");
        }
    }
}
