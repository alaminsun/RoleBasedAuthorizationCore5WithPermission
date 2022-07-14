using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RoleBasedAuthorization.Models;
using RoleBasedAuthorizationCore5.Services.Helpers;
using RoleBasedAuthorizationCore5.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedAuthorizationCore5.Services.Repository
{
    public class AccountRepository : IAccountInfo
    {
        private readonly string _connectionString;
        private readonly IDGenerated _iDGenerated;
        public AccountRepository(IConfiguration configuration, IDGenerated iDGenerated)
        {
            _iDGenerated = iDGenerated;
            //this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }


        public async Task<Admins> GetAdminInfoByEmail(string email)
        {
            string query = "Select id, full_name FullName, email, password, roles_id RolesId, username From Admins where email = '" + email + "'";
            //string query = "Select * From [Identity].Users Where UserName = '" + username + "'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Admins>(query);
                return result;
            }
        }

        public async Task<Admins> GetAdminInfoByUsername(string username)
        {
            string query = "Select id, full_name FullName, email, password, roles_id RolesId, username From Admins where username = '" + username + "'";
            //string query = "Select * From [Identity].Users Where UserName = '" + username + "'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Admins>(query);
                return result;
            }
        }

        public async Task<List<Menus>> GetMenusByRole(int roleId)
        {
            string query = "Select m.id,rm.roles_id,rm.menus_id,m.name,m.icon, m.url, m.parent_id ParentId from link_roles_menus rm, menus m where m.id = rm.menus_id and roles_id = " + roleId + "";
            //string query = "Select * From [Identity].Users Where UserName = '" + username + "'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Menus>(query);
                return result.ToList();
            }
        }


    }
}
