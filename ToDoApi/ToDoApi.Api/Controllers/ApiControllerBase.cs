using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ToDoApi.Api.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected Guid CurrentUserId
        {
            get
            {
                var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return Guid.TryParse(claimValue, out var userId)
                    ? userId
                    : throw new UnauthorizedAccessException("Invalid user ID claim.");
            }
        }
    }
}
