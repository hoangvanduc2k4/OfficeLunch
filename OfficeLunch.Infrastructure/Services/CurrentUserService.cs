using Microsoft.AspNetCore.Http;
using OfficeLunch.Application.Common.Interfaces;
using System.Security.Claims;

namespace OfficeLunch.Infrastructure.Services
{

    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId
        {
            get
            {
                var idClaim = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                if (Guid.TryParse(idClaim, out var userId))
                {
                    return userId;
                }
                return Guid.Empty;
            }
        }

        public string? UserName => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);

        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public bool IsInRole(string role) => _httpContextAccessor.HttpContext?.User?.IsInRole(role) ?? false;

        public string? GetClaim(string claimType) => _httpContextAccessor.HttpContext?.User?.FindFirstValue(claimType);
    }
}