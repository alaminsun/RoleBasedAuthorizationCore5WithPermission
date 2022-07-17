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
    public class MenuRepository : IMenuInfo
    {
        private readonly string _connectionString;
        private readonly IDGenerated _iDGenerated;
        public MenuRepository(IConfiguration configuration, IDGenerated iDGenerated)
        {
            _iDGenerated = iDGenerated;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<Menus>> GetMenus()
        {
            string query = "Select Id, name, icon, url, parent_id ParentId From menus";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Menus>(query);
                return result.ToList();
            }
        }

        public async Task<List<Menus>> GetParentMenus()
        {
            string query = "Select Id, name, icon, url, parent_id ParentId From menus Where parent_id=0";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Menus>(query);
                return result.ToList();
            }
        }

        public async Task<Menus>CreateMenus(Menus menus)
        {
            int MaxID = _iDGenerated.getMAXSLFIN("menus", "id");
            if(menus.Url == "#")
            {
               menus.ParentId = 0;
            }
            
            var query = "INSERT INTO menus (Id, name, icon, url, parent_id ) VALUES (" + MaxID + ",'" + menus.Name + "','" + menus.Icon + "','" + menus.Url + "', "+ menus.ParentId + ")";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var id = await connection.ExecuteAsync(query);

                var menuDTO = new Menus
                {
                    Id = id,
                    Name = menus.Name,
                    Icon = menus.Icon,
                    Url = menus.Url,
                    ParentId = menus.ParentId
                };
                //await connection.ExecuteAsync(query);

                return menuDTO;
            }
        }

        public async Task<Menus>GetMenuById(int? id)
        {
            //string query = "Select id,full_name fullname,email,password,roles_id RolesId, username Username From admins where id = " + Id + "";
            //string query = "Select * From [Identity].Users Where UserName = '" + username + "'";
            string query = "Select Id, name, icon, url, parent_id ParentId From menus Where id= " + id + "";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Menus>(query);
                return result;
            }
        }

        public async Task<List<Menus>> GetParentMenusByParent(int parentId)
        {
            string query = "Select Id, name, icon, url, parent_id ParentId From menus Where parent_id="+parentId+"";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Menus>(query);
                return result.ToList();
            }
        }

        public async Task<int> GetParentIdBy(string url, int parentId, string name)
        {
            string query = "Select Id, name, icon, url, parent_id ParentId From menus Where parent_id=" + parentId + " and url = '"+ url + "' and name = '"+ name +"'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<int>(query);
                return result;
            }
        }
    }
}
