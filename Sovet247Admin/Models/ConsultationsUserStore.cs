using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;


namespace Sovet247Admin.Models
{
    public class ConsultationsUserStore:IUserStore<ConsultationsUser, int>, IUserPasswordStore<ConsultationsUser, int>, IUserLockoutStore<ConsultationsUser,int>,
        IUserTwoFactorStore<ConsultationsUser,int>, IUserRoleStore<ConsultationsUser,int>
    {
        ConsultationsDbContext _context;
        public ConsultationsUserStore(ConsultationsDbContext context)
        {
            _context = context;
        }
        
        public Task CreateAsync(ConsultationsUser user)
        {
            
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ConsultationsUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ConsultationsUser> FindByIdAsync(int userId)
        {
            ConsultationsUser user = new ConsultationsUser(userId);
            Task<ConsultationsUser> task = Task.FromResult<ConsultationsUser>(user);
            return task;
        }

        public Task<ConsultationsUser> FindByNameAsync(string userName)
        {
            ConsultationsUser user = new ConsultationsUser(userName);
            Task<ConsultationsUser> task = Task.FromResult<ConsultationsUser>(user);
            return task;
        }

        public Task UpdateAsync(ConsultationsUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<string> GetPasswordHashAsync(ConsultationsUser user)
        {
            Task<string> task = Task.FromResult(user.UserDetails.password);
            return task;
        }

        public Task<bool> HasPasswordAsync(ConsultationsUser user)
        {
            Task<bool> task = Task.FromResult(user.UserDetails.password!=null);
            return task;
        }

        public Task SetPasswordHashAsync(ConsultationsUser user, string passwordHash)
        {
            Task task = Task.FromResult(user.UserDetails.password = passwordHash);
            return task;
        }

        public Task<int> GetAccessFailedCountAsync(ConsultationsUser user)
        {
            return Task.FromResult<int>(0);
            //throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(ConsultationsUser user)
        {
            return Task.FromResult(false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(ConsultationsUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(ConsultationsUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(ConsultationsUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(ConsultationsUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(ConsultationsUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(ConsultationsUser user)
        {
            return Task.FromResult(false);
            //throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(ConsultationsUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(ConsultationsUser user, string roleName)
        {
            var roleId = _context.Roles
                .Where(r => r.role_title == roleName).First().RoleId;
            user.UserDetails.RoleId = roleId;
            return _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public Task<System.Collections.Generic.IList<string>> GetRolesAsync(ConsultationsUser user)
        {
            var res = new System.Collections.Generic.List<string>();
            
            var roles=_context.Roles.Where(r => r.RoleId==user.UserDetails.RoleId);
            foreach(var role in roles)
            {
                res.Add(role.role_title);
            }

            return Task.FromResult<System.Collections.Generic.IList<string>>(res);
                
            //throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(ConsultationsUser user, string roleName)
        {
            var roles=_context.Roles
                .Where(r => r.role_title == roleName)
                .Where(r => r.RoleId==user.UserDetails.RoleId);
            if (roles.Count() > 0)
                return Task.FromResult<bool>(true);
            else
                return Task.FromResult<bool>(false);
            //throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(ConsultationsUser user, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}