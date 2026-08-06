using System.Security.Claims;
using TrainingCenter.Entities;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public int UserId
        {
            get
            {
                var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
                return int.TryParse(userId, out var id) ? id : 0;
            }
        }

        public Role? Role
        {
            get
            {
                var role = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Role);
                if (Enum.TryParse<Role>(role, true, out var parsedRole))
                {
                    return parsedRole;
                }

                return null;
            }

        }
    }
}