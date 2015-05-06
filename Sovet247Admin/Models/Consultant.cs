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
using System.ComponentModel;
    
    public partial class Consultant
    {
        public Consultant()
        {
            this.Consultations = new HashSet<Consultation>();
        }
    
        public int ConsultantId { get; set; }
        public int ProfessionId { get; set; }
        public Nullable<int> SpecialtyId { get; set; }
        [DisplayName("�������������")]
        public string specialization { get; set; }
        public int UserId { get; set; }
        [DisplayName("�����������")]
        public string education { get; set; }
        [DisplayName("����� ������")]
        public string workplace { get; set; }
        [DisplayName("�������")]
        public bool active { get; set; }
        [DisplayName("������� ������")]
        public string short_resume { get; set; }
        [DisplayName("������� ��������")]
        public Nullable<decimal> comission_percent { get; set; }
        [DisplayName("����������")]
        public string photo_url { get; set; }
    
        [DisplayName("������������")]
        public virtual User User { get; set; }
        [DisplayName("������������")]
        public virtual ICollection<Consultation> Consultations { get; set; }
        [DisplayName("���������")]
        public virtual Profession Profession { get; set; }
        [DisplayName("�������������")]
        public virtual Specialty Specialty { get; set; }
    }
}
