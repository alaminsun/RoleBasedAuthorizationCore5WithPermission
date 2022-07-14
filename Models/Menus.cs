using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models
{
    public partial class Menus
    {
        public Menus()
        {
            LinkRolesMenus = new List<LinkRolesMenus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int ParentId { get; set; }

        public IList<LinkRolesMenus> LinkRolesMenus { get; set; }
    }
}
