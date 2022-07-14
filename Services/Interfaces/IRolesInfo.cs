using RoleBasedAuthorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedAuthorizationCore5.Services.Interfaces
{
    public interface IRolesInfo
    {
        Task<List<Roles>> GetRoles();
        Task<Roles> CreateRoles(Roles roles);
        Task<Roles> GetRoleById(int? id);
        Task<List<string>> GetRoleWiseMenu(int? id);
        Task<List<Menus>> GetMenus();
        Task<Roles> UpdateRole(Roles roles);
        Task<List<LinkRolesMenus>> GetLinkMenuByRole(int id);
        void DeleteAsync(LinkRolesMenus item);
        void AddAsync(int role, int id);
    }
}
