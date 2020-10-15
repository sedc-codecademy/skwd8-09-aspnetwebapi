using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Services.Interfaces
{
    public interface IControllerUtilityService
    {
        Guid GetAuthorizedUserId(ClaimsPrincipal user);
    }
}
