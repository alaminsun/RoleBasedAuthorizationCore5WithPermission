using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedAuthorizationCore5.Services.Interfaces
{
    public interface IAdminInfo 
    {
        Task<Roles> GetRolesById(int? rolesId);
        Task<List<Roles>> GetRoles();
        Task<List<Admins>> GetAdmins();
        Task<Admins> CreateAdmin([Bind("Id,FullName,Email,Password,RolesId")] Admins admins);
        Task<Admins> GetAdminById(int? id);
        Task<Admins> UpdateAdmin(Admins admins);
        Task<Admins> GetDeleteByAdminId(Admins admins);
    }
}
