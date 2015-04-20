using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Sovet247Admin.Models
{
    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomRoleStore : RoleStore<Role, int, CustomUserRole>, IRoleStore<Role,int>
    {
        ConsultationsDbContext _context;
        public CustomRoleStore(ConsultationsDbContext context):base(context)
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
            Task<Role> task=_context.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId);
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