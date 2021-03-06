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
    
    public partial class Consultation
    {
        public Consultation()
        {
            this.Consultation_Time = new HashSet<Consultation_Time>();
            this.Messages = new HashSet<Message>();
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int ConsultationId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> ConsultantId { get; set; }
        public string subject { get; set; }
        public int consultation_type { get; set; }
        public int ProfessionId { get; set; }
        public Nullable<int> SpecialtyId { get; set; }
        public int consultation_status { get; set; }
        public System.DateTime create_date { get; set; }
        public System.DateTime update_date { get; set; }
        public Nullable<decimal> customer_rating { get; set; }
        public string customer_comments { get; set; }
        public decimal consultation_price { get; set; }
        public string admin_comments { get; set; }
        public short urgency { get; set; }
        public short detalization { get; set; }
    
        public virtual Consultant Consultant { get; set; }
        public virtual Consultation_Statuses Consultation_Statuses { get; set; }
        public virtual ICollection<Consultation_Time> Consultation_Time { get; set; }
        public virtual Consultation_Types Consultation_Types { get; set; }
        public virtual Profession Profession { get; set; }
        public virtual Specialty Specialty { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual User User { get; set; }
    }
}
