using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Sovet247Admin.Models
{
    public class ConsultationsRoleStore : RoleStore<ConsultationsRole, int, ConsultationsUserRole>, IRoleStore<ConsultationsRole, int>
    {
        readonly ConsultationsIdentityDbContext _context;
        public ConsultationsRoleStore(ConsultationsIdentityDbContext context)
            : base(context)
        {
            _context = context;
        }

        Task IRoleStore<ConsultationsRole, int>.CreateAsync(ConsultationsRole role)
        {
            throw new NotImplementedException();
        }

        Task IRoleStore<ConsultationsRole, int>.DeleteAsync(ConsultationsRole role)
        {
            throw new NotImplementedException();
        }

        Task<ConsultationsRole> IRoleStore<ConsultationsRole, int>.FindByIdAsync(int roleId)
        {
            Task<ConsultationsRole> task = Task.FromResult<ConsultationsRole>(_context.Roles.FirstOrDefault(r => r.RoleDetails.RoleId == roleId));
            return task;
        }

        Task<ConsultationsRole> IRoleStore<ConsultationsRole, int>.FindByNameAsync(string roleName)
        {
            Task<ConsultationsRole> task = Task.FromResult<ConsultationsRole>(_context.Roles.FirstOrDefault(r => r.RoleDetails.role_title == roleName));
            return task;
        }

        Task IRoleStore<ConsultationsRole, int>.UpdateAsync(ConsultationsRole role)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}