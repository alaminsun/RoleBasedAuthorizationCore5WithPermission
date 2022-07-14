using RoleBasedAuthorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedAuthorizationCore5.Services.Interfaces
{
    public interface IMenuInfo
    {
       
        Task<List<Menus>> GetMenus();
        Task<Menus> CreateMenus(Menus menus);
        Task<List<Menus>> GetParentMenus();
    }
}
