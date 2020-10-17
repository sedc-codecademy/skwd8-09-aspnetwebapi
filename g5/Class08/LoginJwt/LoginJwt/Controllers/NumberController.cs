//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace LoginJwt.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class NumberController : ControllerBase
//    {
//        [HttpGet]
//        [Authorize(Roles = "All")]
//        public ActionResult<List<int>> GetRandomNumbers()
//        {
//            var jwtToken = Request.Headers["Authorization"][0].Replace("Bearer ", "");
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var token = tokenHandler.ReadJwtToken(jwtToken);
//            var claimId = token.Claims.FirstOrDefault(x => x.Type == "nameid");

//            if (claimId != null)
//            {
//                var id = claimId.Value;
//            }

//            var numbers = new List<int>();
//            var rnd = new Random();

//            for (int i = 0; i < 10; i++)
//            {
//                numbers.Add(rnd.Next(1, 10000000));
//            }

//            return numbers;
//        }
//    }
//}
