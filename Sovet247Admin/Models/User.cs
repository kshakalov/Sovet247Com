//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sovet247Admin.Models
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    public partial class User:IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim> ,IUser<int>
    {
        public User()
        {
            this.Consultants = new HashSet<Consultant>();
            this.Messages = new HashSet<Message>();
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int UserId { get; set; }
        public string nickname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public string street_address { get; set; }
        public string city { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string phone { get; set; }
        public short wants_newsletter { get; set; }
        public string alternate_contacts { get; set; }
        public string comments { get; set; }
        public short can_publish_questions { get; set; }
        public int RoleId { get; set; }
    
        public virtual ICollection<Consultant> Consultants { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

        [NotMapped]
        new public virtual int Id
        {
            get { return UserId; }
            set { UserId = value; }
        }


        [NotMapped]
        new public virtual string UserName
        {
            get
            {
                return email;
            }
            set
            {
                email=value;
            }
        }

        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User,int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }
}
