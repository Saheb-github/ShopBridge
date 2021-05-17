using ShopBride.BussinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.BussinessProcess.Interfaces
{
    public interface ISBUserManager
    {
        Task<UserInfo> GetuserDetails(string email, string password);
    }
}
