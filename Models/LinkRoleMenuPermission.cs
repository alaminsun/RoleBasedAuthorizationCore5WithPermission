using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedAuthorizationCore5.Models
{
    public class LinkRoleMenuPermission
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string URL { get; set; }
        public Boolean ViewPermission { get; set; } = false;
        public Boolean CreatePermission { get; set; } = false;
        public Boolean EditPermission { get; set; } = false;
        public Boolean DeletePermission { get; set; } = false;
        public int Sl { get; internal set; }
        public int PermissionId { get; set; }
        public bool Iselected { get; set; }
        //public Boolean PrintPermission { get; set; }

        //public virtual ICollection<RoleInFormBEL> detailsList { get; set; }
    }
}
