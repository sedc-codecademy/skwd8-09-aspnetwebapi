using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Class01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new List<User>()
            {
                new User()
                {
                    FirstName = "Risto",
                    LastName = "Panchevski"
                },
                new User()
                {
                    FirstName = "Petko",
                    LastName = "Petkovski"
                }
            };
        }

        [HttpPost]
        public User Add(User user)
        {
            return user;
        }
    }
}
