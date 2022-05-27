using sycXF.Models.Token;
using System.Threading.Tasks;

namespace sycXF.Services.Identity
{
    public interface IIdentityService
    {
        string CreateAuthorizationRequest();
        string CreateLogoutRequest(string token);
        Task<UserToken> GetTokenAsync(string code);
    }
}