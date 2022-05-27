using sycXF.Models.User;
using System.Threading.Tasks;

namespace sycXF.Services.User
{
    public interface IUserService
    {
        Task<UserInfo> GetUserInfoAsync(string authToken);
    }
}
