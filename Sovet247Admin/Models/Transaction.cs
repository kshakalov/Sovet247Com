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
    
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public decimal amount { get; set; }
        public System.DateTime transactionDate { get; set; }
        public string description { get; set; }
        public Nullable<int> ConsultationId { get; set; }
        public bool isApproved { get; set; }
    
        public virtual Consultation Consultation { get; set; }
        public virtual User User { get; set; }
    }
}
