using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Sovet247Admin.Models
{
    public class ConsultationsUser : IdentityUser<int, ConsultationsUserLogin, ConsultationsUserRole, ConsultationsUserClaim>, IUser<int>
    {
        public User UserDetails;
        private readonly ConsultationsDbContext _context;
        public ConsultationsUser()
        {
            _context = new ConsultationsDbContext();
        }

        public ConsultationsUser(string email):this()
        {
            UserDetails = _context.Users.FirstOrDefault(u => u.email == email);
            if (UserDetails!=null)
            {
                Id = UserDetails.UserId;
                UserName = UserDetails.email;
            }
        }

        public ConsultationsUser(int userId):this()
        {
            UserDetails = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (UserDetails == null) return;
            Id = UserDetails.UserId;
            UserName = UserDetails.email;
        }
        public int Id{get; set;}
        public string UserName {get; set;}
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ConsultationsUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}