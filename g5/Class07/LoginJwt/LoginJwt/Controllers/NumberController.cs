using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult<List<int>> GetRandomNumbers()
        {
            var numbers = new List<int>();
            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(rnd.Next(1, 10000000));
            }

            return numbers;
        }
    }
}
