using Dapper;
using Microsoft.AspNetCore.Mvc;
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
    public class AdminRepository : IAdminInfo
    {
        private readonly string _connectionString;
        private readonly IDGenerated _iDGenerated;
        public readonly IAdminInfo _adminInfo;
        public AdminRepository(IConfiguration configuration, IDGenerated iDGenerated)
        {
            _iDGenerated = iDGenerated;
            //this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }
        public async Task<Roles> GetRolesById(int? rolesId)
        {
            string query = "Select id Roles_Master_Id, Title, Description From roles where id = " + rolesId + "";
            //string query = "Select * From [Identity].Users Where UserName = '" + username + "'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Roles>(query);
                return result;
            }
        }

        public async Task<Admins> GetAdminById(int? Id)
        {
            string query = "Select id,full_name fullname,email,password,roles_id RolesId, username Username From admins where id = " + Id + "";
            //string query = "Select * From [Identity].Users Where UserName = '" + username + "'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Admins>(query);
                return result;
            }
        }


        public async Task<List<Roles>> GetRoles()
        {
            string query = "Select id Roles_Master_Id, Title, Description From roles";
            //string query = "Select * From [Identity].Users Where UserName = '" + username + "'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Roles>(query);
                return result.ToList();
            }
        }

        public async Task<List<Admins>> GetAdmins()
        {
            string query = "Select a.id Id, a.full_name FullName, a.username Username, a.email Email , a.password Password, b.id as RolesId, b.title, b.description From admins a, roles b Where a.roles_id = b.id";
            //string query = "Select * From [Identity].Users Where UserName = '" + username + "'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Admins>(query);
                return result.ToList();
            }
        }

        public async Task<Admins> CreateAdmin([Bind("Id,FullName,Email,Password,RolesId")] Admins admins)
        {
                int MaxID = _iDGenerated.getMAXSLFIN("admins", "id");

                var query = "INSERT INTO admins (Id, full_name, email, password, roles_id) VALUES (" + MaxID + ",'" + admins.FullName + "','" + admins.Email + "','" + admins.Password + "'," + admins.RolesId + ")";
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                var id = await connection.ExecuteAsync(query);

                var adminDTO = new Admins
                {
                    Id = id,
                    FullName = admins.FullName,
                    Email = admins.Email,
                    Password = admins.Password,
                    RolesId = admins.RolesId
                };
                await connection.ExecuteAsync(query);

                 return adminDTO;
                }

            
        }

        public async Task<Admins>UpdateAdmin(Admins admins)
        {
            //int MaxID = _iDGenerated.getMAXSLFIN("admins", "id");

            //var query = "INSERT INTO admins (Id, full_name, email, password, roles_id) VALUES (" + MaxID + ",'" + admins.FullName + "','" + admins.Email + "','" + admins.Password + "'," + admins.RolesId + ")";
            var query = "Update Admins Set full_name = '"+admins.FullName+"', email= '"+admins.Email+"', roles_id = "+admins.RolesId+" Where Id="+admins.Id+"";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var id = await connection.ExecuteAsync(query);

                var adminDTO = new Admins
                {
                    //Id = id,
                    FullName = admins.FullName,
                    Email = admins.Email,
                    //Password = admins.Password,
                    RolesId = admins.RolesId
                };
                //await connection.ExecuteAsync(query);

                return adminDTO;
            }
        }

        public async Task<Admins>GetDeleteByAdminId(Admins admins)
        {
            var query = "Delete From Admins Where Id = "+admins.Id+"";
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(query);

                return admins;
            }
        }
    }
}
