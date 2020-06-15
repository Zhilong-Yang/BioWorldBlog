using System.Threading.Tasks;
using BioWorld.Application.Common.Models;

namespace BioWorld.Application.Common.Interface
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}