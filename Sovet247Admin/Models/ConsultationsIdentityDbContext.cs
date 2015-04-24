using Microsoft.AspNet.Identity.EntityFramework;

namespace Sovet247Admin.Models
{
    public class ConsultationsIdentityDbContext:IdentityDbContext<ConsultationsUser,ConsultationsRole, int,ConsultationsUserLogin, ConsultationsUserRole, ConsultationsUserClaim>
     {
         public ConsultationsIdentityDbContext()
             : base("name=consultationsConnectionString")
         {
         }

         public static ConsultationsIdentityDbContext Create()
         {
             return new ConsultationsIdentityDbContext();
         }
     }
}