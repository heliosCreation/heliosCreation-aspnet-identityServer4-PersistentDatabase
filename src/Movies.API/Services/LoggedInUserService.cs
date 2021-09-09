using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Movies.API.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly ClaimsPrincipal _user;

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _user = httpContextAccessor.HttpContext?.User;
        }

        public string getName()
        {
            return _user?.Identity?.Name;
        }

        public string getUserSub()
        {
            return _user?
                .Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
                .Value;
        }

        public string getAddress()
        {
            return _user?
                .Claims.FirstOrDefault(c => c.Type == "address")?
                .Value;
        }
    }
}
