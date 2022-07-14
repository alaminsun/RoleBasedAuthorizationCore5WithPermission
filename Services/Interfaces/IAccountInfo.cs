using RoleBasedAuthorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedAuthorizationCore5.Services.Interfaces
{
    public interface IAccountInfo
    {
        Task<Admins> GetAdminInfoByEmail(string email);
        Task<List<Menus>> GetMenusByRole(int roleId);
        Task<Admins> GetAdminInfoByUsername(string username);
    }
}
