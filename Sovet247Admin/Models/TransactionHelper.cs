using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{ 
    [MetadataType(typeof (TransactionHelper))]
    public partial class Transaction
    {
    }

    public partial class TransactionHelper
    {
        public int TransactionId { get; set; }

        [DisplayName("Пользователь")]
        public int UserId { get; set; }

        [DisplayName("Сумма")]
        public decimal amount { get; set; }

        [DisplayName("Дата транзакции")]
        public System.DateTime transactionDate { get; set; }

        [DisplayName("Описание транзакции")]
        public string description { get; set; }

        [DisplayName("Консультация")]
        public Nullable<int> ConsultationId { get; set; }

        [DisplayName("Утверждена администратором")]
        public bool isApproved { get; set; }

    }
}