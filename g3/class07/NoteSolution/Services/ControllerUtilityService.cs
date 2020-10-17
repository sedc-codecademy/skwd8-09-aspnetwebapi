using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class ControllerUtilityService : IControllerUtilityService
    {
        public Guid GetAuthorizedUserId(ClaimsPrincipal user)
        {
            if (!Guid.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                string name = user.FindFirst(ClaimTypes.Name)?.Value;
                throw new Exception("Name identifier claim does not exist!");
            }
            return userId;
        }
    }
}
