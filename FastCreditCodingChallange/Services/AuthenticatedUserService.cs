using System.Security.Claims;

namespace FastCreditCodingChallange.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            _ = int.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue("userId"), out int userKey);
            UserId = userKey;
        }

        public int UserId { get; set; }
    }
}
