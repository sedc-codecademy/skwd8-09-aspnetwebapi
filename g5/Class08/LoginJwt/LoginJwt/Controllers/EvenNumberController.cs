//using System;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace LoginJwt.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EvenNumberController : ControllerBase
//    {
//        [HttpGet]
//        [Authorize(Roles = "Even")]
//        public ActionResult<List<int>> GetEvenRandomNumber()
//        {
//            var rnd = new Random();
//            List<int> evenNumbers = new List<int>();

//            while (evenNumbers.Count <= 10)
//            {
//                var number = rnd.Next(1, 10000000);

//                if (number % 2 == 0)
//                {
//                    evenNumbers.Add(number);
//                }
//            }

//            return evenNumbers;
//        }
//    }
//}
