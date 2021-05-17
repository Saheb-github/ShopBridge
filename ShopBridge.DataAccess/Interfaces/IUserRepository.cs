using ShopBride.BussinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        List<UserInfo> GetUserDetails(string email, string password);
    }
}
