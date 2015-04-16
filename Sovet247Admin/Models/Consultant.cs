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
    using System;
    using System.Collections.Generic;
    
    public partial class Consultant
    {
        public Consultant()
        {
            this.Consultations = new HashSet<Consultation>();
        }
    
        public int ConsultantId { get; set; }
        public int ProfessionId { get; set; }
        public Nullable<int> SpecialtyId { get; set; }
        public string specialization { get; set; }
        public int UserId { get; set; }
        public string education { get; set; }
        public string workplace { get; set; }
        public bool active { get; set; }
        public string short_resume { get; set; }
        public Nullable<decimal> comission_percent { get; set; }
        public string photo_url { get; set; }
    
        public virtual User User { get; set; }
        public virtual ICollection<Consultation> Consultations { get; set; }
    }
}