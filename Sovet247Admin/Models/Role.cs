//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sovet247Admin.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Role:IdentityRole<int, CustomUserRole>, IRole<int>
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
    
        public int RoleId { get; set; }
        public string role_title { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
        [NotMapped]
        new public int Id
        {
            get { return RoleId; }
        }
        [NotMapped]
        new public string Name
        {
            get
            {
                return role_title;
            }
            set
            {
                role_title=value;
            }
        }
    }
}
