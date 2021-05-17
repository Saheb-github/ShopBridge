using ShopBride.BussinessEntities.Models;
using ShopBridge.BussinessProcess.Interfaces;
using ShopBridge.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.BussinessProcess.Services
{
    public class SBUserManager : ISBUserManager
    {
        readonly IUserRepository _userRepository;
        public SBUserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserInfo> GetuserDetails(string email, string password)
        {
           var userDetails= _userRepository.GetUserDetails(email, password);
            if (userDetails != null)
            {
                return Task.FromResult(userDetails.FirstOrDefault());
            }
            return Task.FromResult<UserInfo>(null);
        }
    }
}
