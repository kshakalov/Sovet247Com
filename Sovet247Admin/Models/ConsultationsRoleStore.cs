using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    public class ConsultationsRoleStore : RoleStore<ConsultationsRole, int, ConsultationsUserRole>, IRoleStore<ConsultationsRole, int>
    {
        ConsultationsIdentityDbContext _context;
        public ConsultationsRoleStore(ConsultationsIdentityDbContext context)
            : base(context)
        {
            _context = context;
        }

        Task IRoleStore<ConsultationsRole, int>.CreateAsync(ConsultationsRole role)
        {
            throw new System.NotImplementedException();
        }

        Task IRoleStore<ConsultationsRole, int>.DeleteAsync(ConsultationsRole role)
        {
            throw new System.NotImplementedException();
        }

        Task<ConsultationsRole> IRoleStore<ConsultationsRole, int>.FindByIdAsync(int roleId)
        {
            Task<ConsultationsRole> task = Task.FromResult<ConsultationsRole>(_context.Roles.Where(r => r.RoleDetails.RoleId == roleId).FirstOrDefault());
            return task;
        }

        Task<ConsultationsRole> IRoleStore<ConsultationsRole, int>.FindByNameAsync(string roleName)
        {
            Task<ConsultationsRole> task = Task.FromResult<ConsultationsRole>(_context.Roles.Where(r => r.RoleDetails.role_title == roleName).FirstOrDefault());
            return task;
        }

        Task IRoleStore<ConsultationsRole, int>.UpdateAsync(ConsultationsRole role)
        {
            throw new System.NotImplementedException();
        }

        void System.IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}