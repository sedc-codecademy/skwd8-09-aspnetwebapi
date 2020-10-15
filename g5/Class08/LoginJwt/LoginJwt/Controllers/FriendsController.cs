//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using LoginJwt.StaticData;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using ViewModels;

//namespace LoginJwt.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FriendsController : ControllerBase
//    {
//        [HttpGet]
//        [Route("{id}")]
//        [Authorize(Roles = "Friends")]
//        public ActionResult<List<FriendViewModel>> GetAllFriends(int id)
//        {
//            var jwtToken = Request.Headers["Authorization"][0].Replace("Bearer ", "");
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var token = tokenHandler.ReadJwtToken(jwtToken);
//            var claimId = token.Claims.FirstOrDefault(x => x.Type == "nameid");
//            var userId = int.Parse(claimId.Value);

//            if (userId != id)
//            {
//                return Unauthorized();
//            }

//            return FriendsList.Friends.Where(x => x.FriendOfUserId == id).ToList();
//        }
//    }
//}
