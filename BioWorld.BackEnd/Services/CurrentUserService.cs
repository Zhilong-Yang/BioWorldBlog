using System.Security.Claims;
using BioWorld.Application.Common.Interface;
using Microsoft.AspNetCore.Http;

namespace BioWorld.BackEnd.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
