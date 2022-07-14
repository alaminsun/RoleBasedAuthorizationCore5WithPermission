using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuthorization.Models
{
    public partial class Admins
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        //[Remote("CheckUsernameAvailability", "Admins", ErrorMessage = "User Name already in use")]
        [Required]
        [MinLength(2, ErrorMessage = "Username length will be more than 2.")]
        //[Remote(action: "CheckUsernameAvailability", controller: "Admins")]
        [Remote("CheckUsernameAvailability", "Admins", HttpMethod = "POST", ErrorMessage = "UserName already in use.")]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int? RolesId { get; set; }

        public Roles Roles { get; set; }
    }
}
