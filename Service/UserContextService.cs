using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WholeSaler.Context;
using WholeSaler.Entity;
using WholeSaler.IService;

namespace WholeSaler.Service
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CoreContext _coreContext;

        public UserContextService(IHttpContextAccessor httpContextAccessor, CoreContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _coreContext = context;
        }

        public async Task<User> GetUser()
        {
            var id= long.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _coreContext.users.SingleOrDefaultAsync(el => el.UserId == id);
            return user;
        }
        public async Task<bool> IsUserManager()
        {
            var role=_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            return role is "manager";
        }
    }
}
