using sycXF.Helpers;
using sycXF.Models.User;
using System;
using System.Threading.Tasks;

namespace sycXF.Services.User
{
    public class UserService : IUserService
    {

        public UserService()
        {
        }

        public Task<UserInfo> GetUserInfoAsync(string authToken)
        {
            throw new NotImplementedException();
        }
    }
}