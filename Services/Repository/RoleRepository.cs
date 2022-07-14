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
    public class RoleRepository : IRolesInfo
    {

        private readonly string _connectionString;
        private readonly IDGenerated _iDGenerated;
        public RoleRepository(IConfiguration configuration, IDGenerated iDGenerated)
        {
            _iDGenerated = iDGenerated;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<Roles>> GetRoles()
        {
            string query = " Select id Roles_Master_Id , title, description From roles";
            //string query = "Select * From [Identity].Users Where UserName = '" + username + "'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Roles>(query);
                return result.ToList();
            }
        }

        public async Task<Roles> CreateRoles(Roles roles)
        {
            int MaxID = _iDGenerated.getMAXSLFIN("roles", "id");

            var query = "INSERT INTO roles (Id, title, description) VALUES (" + MaxID + ",'" + roles.Title + "','" + roles.Description + "')";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var id = await connection.ExecuteAsync(query);
                if (id > 0)
                {
                    foreach (var detail in roles.RolesDetails)
                    {
                        if (detail.Roles_Detail_Id == 0 )
                        {
                            detail.Roles_Detail_Id = _iDGenerated.getMAXSLFIN("RoleWisePermission", "Id");
                            var queryDetail = "INSERT INTO RoleWisePermission (Id, RoleId, MenuId, MenuName, Url, ViewPermission, CreatePermission, UpdatePermission, DeletePermission) VALUES (" + detail.Roles_Detail_Id + "," + MaxID + "," + detail.MenuId + ", '"+detail.MenuName+"', '"+detail.Url+"', '"+detail.View+ "','" + detail.Create + "', '" + detail.Edit + "', '" + detail.Delete + "')";
                            await connection.ExecuteAsync(queryDetail);

                        }
                        else
                        {
                            var queryDelete = "Delete From RoleWisePermission Where RoleId= " + roles.Roles_Master_Id + "";
                            await connection.ExecuteAsync(queryDelete);
                            var queryDetail = "INSERT INTO RoleWisePermission (Id, RoleId, MenuId, MenuName, Url, [View], [Create], [Update], [Delete]) VALUES (" + detail.Roles_Detail_Id + "," + detail.RolesId + "," + detail.MenuId + ", " + detail.MenuName + ", '" + detail.Url + "', " + detail.View + "," + detail.Create + ", " + detail.Edit + ", " + detail.Delete + ")";
                            await connection.ExecuteAsync(queryDetail);
                        }

                    }

                }
                var roleDTO = new Roles
                {
                    Roles_Master_Id = id,
                    Title = roles.Title,
                    Description = roles.Description,
                    RolesDetails = roles.RolesDetails

                };
                //await connection.ExecuteAsync(query);

                return roleDTO;
            }
        }

        public async Task<Roles> GetRoleById(int? id)
        {
            string query = "Select id Roles_Master_Id , title, description From roles Where Id = " + id+"";
            //string query = "Select * From [Identity].Users Where UserName = '" + username + "'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Roles>(query);
                //string query = "Select * From [Identity].Users Where UserName = '" + username + "'";
                var roleDTO = new Roles
                {
                    Roles_Master_Id = result.Roles_Master_Id,
                    Title = result.Title,
                    Description = result.Description
                };
                return roleDTO;
            }
        }

        public async Task<List<string>> GetRoleWiseMenu(int? id)
        {
            //string query = "Select m.id,rm.roles_id,rm.menus_id,m.name,m.icon, m.url, m.parent_id ParentId from link_roles_menus rm, menus m where m.id = rm.menus_id and roles_id = " + id + "";
            string query = "Select menus_id from link_roles_menus Where roles_id = " + id + "";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<string>(query);
                return result.ToList();
            }
        }

        public async Task<List<Menus>> GetMenus()
        {
            string query = "Select id,name,icon,url,parent_id ParentId From menus";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Menus>(query);
                return result.ToList();
            }
        }

        public async Task<Roles> UpdateRole(Roles roles)
        {
            //int MaxID = _iDGenerated.getMAXSLFIN("roles", "id");

            //var query = "INSERT INTO roles (Id, title, description) VALUES (" + MaxID + ",'" + roles.Title + "','" + roles.Description + "')";
            var query = "Update roles Set Title = '"+ roles.Title + "' , Description= '"+ roles.Description+ "' Where Id="+roles.Roles_Master_Id+"";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var id = await connection.ExecuteAsync(query);

                var roleDTO = new Roles
                {
                    Roles_Master_Id = id,
                    Title = roles.Title,
                    Description = roles.Description
                };
                //await connection.ExecuteAsync(query);

                return roleDTO;
            }
        }

        public async Task<List<LinkRolesMenus>> GetLinkMenuByRole(int id)
        {
            string query = "Select id,roles_id RolesId,menus_id MenusId From link_roles_menus Where roles_id = " + id+"";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<LinkRolesMenus>(query);
                return result.ToList();
            }
        }

        public async void DeleteAsync(LinkRolesMenus item)
        {
            string query = "Delete From link_roles_menus Where roles_id = "+item.RolesId+ " And menus_id = "+item.MenusId+"";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                await connection.QueryAsync<LinkRolesMenus>(query);
                
            }
        }

        public async void AddAsync(int role, int id)
        {
            int MaxID = _iDGenerated.getMAXSLFIN("link_roles_menus", "id");
            string query = "INSERT INTO link_roles_menus (Id, roles_id, menus_id) VALUES (" + MaxID + "," + id + "," + role + ")";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                await connection.QueryAsync<LinkRolesMenus>(query);

            }
        }
    }
}
