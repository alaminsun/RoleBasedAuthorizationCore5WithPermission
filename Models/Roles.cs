using System;
using System.Collections.Generic;

namespace RoleBasedAuthorization.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Admins = new List<Admins>();
            LinkRolesMenus = new List<LinkRolesMenus>();
            RolesDetails = new List<RolesDetailModel>();
        }

        public int Roles_Master_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //public ICollection<Admins> Admins { get; set; }
        //public ICollection<LinkRolesMenus> LinkRolesMenus { get; set; }
        public IList<Admins> Admins { get; set; }
        public IList<LinkRolesMenus> LinkRolesMenus { get; set; }
        public List<RolesDetailModel> RolesDetails { get; set; }
    }


    public class RolesDetailModel
    {
        public int Roles_Detail_Id { get; set; }
        public int Roles_Master_Id { get; set; }
        public int Sl { get; set; }
        public int RolesId { get; set; }
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public Boolean View { get; set; }
        public Boolean Create { get; set; }
        public Boolean Edit { get; set; }
        public Boolean Delete { get; set; }
        //public int Stock_Qty { get; set; }
        //public int Quantity { get; set; }
        //public decimal Total_Price { get; set; }
        //public decimal Grand_Total { get; set; }
        //public decimal Discount_Price { get; set; }
        //public string CreatedOn { get; set; }
        //public string LastModifiedOn { get; set; }
    }
}
