using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;


namespace Sovet247Admin.Models
{
    public class ConsultationsUserStore:IUserStore<User, int>, IUserPasswordStore<User, int>, IUserLockoutStore<User,int>,
        IUserTwoFactorStore<User,int>, IUserRoleStore<User,int>
    {
        ConsultationsDbContext _context;
        public ConsultationsUserStore(ConsultationsDbContext context)
        {
            _context = context;
        }
        
        public Task CreateAsync(User user)
        {
            
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(int userId)
        {
            Task<User> task = _context.Users.Where(u=>u.UserId==userId).FirstOrDefaultAsync();
            return task;
        }

        public Task<User> FindByNameAsync(string userName)
        {
            Task<User> task = _context.Users.Where(u => u.email == userName).FirstOrDefaultAsync();
            return task;
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            Task<string> task = Task.FromResult(user.password);
            return task;
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            Task<bool> task = Task.FromResult(user.password!=null);
            return task;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            Task task = Task.FromResult(user.password = passwordHash);
            return task;
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(false);
            //throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(User user, string roleName)
        {
            var roleId = _context.Roles
                .Where(r => r.role_title == roleName).First().RoleId;
            user.RoleId = roleId;
            return _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public Task<System.Collections.Generic.IList<string>> GetRolesAsync(User user)
        {
            var res = new System.Collections.Generic.List<string>();
            
            var roles=_context.Roles.Where(r => r.RoleId==user.RoleId);
            foreach(var role in roles)
            {
                res.Add(role.role_title);
            }

            return Task.FromResult<System.Collections.Generic.IList<string>>(res);
                
            //throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            var roles=_context.Roles
                .Where(r => r.role_title == roleName)
                .Where(r => r.Users.Contains(user));
            if (roles.Count() > 0)
                return Task.FromResult<bool>(true);
            else
                return Task.FromResult<bool>(false);
            //throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}