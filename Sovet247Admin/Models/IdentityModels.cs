using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Sovet247Admin.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    /* public class ApplicationDbContext : IdentityDbContext<User,Role, int,CustomUserLogin, CustomUserRole, CustomUserClaim>
     {
         public ApplicationDbContext()
             : base("name=ConsultationsDbContext")
         {
         }

         public static ApplicationDbContext Create()
         {
             return new ApplicationDbContext();
         }
     }*/

    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomRoleStore : RoleStore<Role, int, CustomUserRole>, IRoleStore<Role, int>
    {
        ConsultationsDbContext _context;
        public CustomRoleStore(ConsultationsDbContext context)
            : base(context)
        {
            _context = context;
        }


        Task IRoleStore<Role, int>.CreateAsync(Role role)
        {
            throw new System.NotImplementedException();
        }

        Task IRoleStore<Role, int>.DeleteAsync(Role role)
        {
            throw new System.NotImplementedException();
        }

        Task<Role> IRoleStore<Role, int>.FindByIdAsync(int roleId)
        {
            Task<Role> task = _context.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId);
            return task;
        }

        Task<Role> IRoleStore<Role, int>.FindByNameAsync(string roleName)
        {
            Task<Role> task = _context.Roles.FirstOrDefaultAsync(r => r.role_title == roleName);
            return task;
        }

        Task IRoleStore<Role, int>.UpdateAsync(Role role)
        {
            throw new System.NotImplementedException();
        }

        void System.IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}