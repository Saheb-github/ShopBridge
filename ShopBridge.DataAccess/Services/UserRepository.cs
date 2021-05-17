using Dapper;
using Microsoft.Extensions.Configuration;
using ShopBride.BussinessEntities.Models;
using ShopBridge.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ShopBridge.DataAccess.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        private readonly IDbConnection db;

        public UserRepository(IConfiguration config)
        {
            _config = config;
            var connectionString = _config.GetSection("App:Connection:DefaultConnection").Value;
            db = new SqlConnection(connectionString);
        }
        public List<UserInfo> GetUserDetails(string email, string password)
        {
            string query = "select * from UserInfo where email= '" + email +"'"+" and password= '" + password+"'";
            return (List<UserInfo>)db.Query<UserInfo>(query);
        }
    }
}
