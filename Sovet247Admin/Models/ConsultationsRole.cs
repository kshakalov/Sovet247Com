using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Sovet247Admin.Models
{
    public class ConsultationsRole : IdentityRole<int, ConsultationsUserRole>
    {
        public Role RoleDetails;
        private readonly ConsultationsDbContext _context;
        public ConsultationsRole() {
            _context = new ConsultationsDbContext();
            RoleDetails = new Role();
        }
        public ConsultationsRole(string name) {
            Name = name;
            RoleDetails = _context.Roles.FirstOrDefault(r => r.role_title == name);
            if (RoleDetails == null) return;
            Name = RoleDetails.role_title;
            Id = RoleDetails.RoleId;
        }
    }
}