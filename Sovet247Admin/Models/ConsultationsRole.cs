using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    public class ConsultationsRole : IdentityRole<int, ConsultationsUserRole>
    {
        public Role RoleDetails;
        private ConsultationsDbContext _context;
        public ConsultationsRole() {
            _context = new ConsultationsDbContext();
            RoleDetails = new Role();
        }
        public ConsultationsRole(string name) {
            Name = name;
            RoleDetails = _context.Roles.Where(r => r.role_title == name).FirstOrDefault();
            if(RoleDetails!=null)
            {
                Name = RoleDetails.role_title;
                Id = RoleDetails.RoleId;
            }
        }
    }
}