//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sovet247Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Specialty
    {
        public Specialty()
        {
            this.Consultations = new HashSet<Consultation>();
            this.Consultants = new HashSet<Consultant>();
        }
    
        public int SpecialtyId { get; set; }
        public string Specialty_title { get; set; }
        public int ProfessionId { get; set; }
        public bool active { get; set; }
    
        public virtual ICollection<Consultation> Consultations { get; set; }
        public virtual Profession Profession { get; set; }
        public virtual ICollection<Consultant> Consultants { get; set; }
    }
}
