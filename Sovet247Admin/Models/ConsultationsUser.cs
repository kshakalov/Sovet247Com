using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sovet247Admin.Models
{
    public class ConsultationsUser : IdentityUser<int, ConsultationsUserLogin, ConsultationsUserRole, ConsultationsUserClaim>, IUser<int>
    {
        public User UserDetails;
        private ConsultationsDbContext context;
        public ConsultationsUser()
        {
            context = new ConsultationsDbContext();
        }

        public ConsultationsUser(string email):this()
        {
            UserDetails = context.Users.Where(u => u.email == email).FirstOrDefault();
            if (UserDetails!=null)
            {
                Id = UserDetails.UserId;
                UserName = UserDetails.email;
            }
        }

        public ConsultationsUser(int userId):this()
        {
            UserDetails = context.Users.Where(u => u.UserId == userId).FirstOrDefault();
            if (UserDetails != null)
            {
                Id = UserDetails.UserId;
                UserName = UserDetails.email;
            }
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