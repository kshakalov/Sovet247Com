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
    
    public partial class User
    {
        public User()
        {
            this.Consultants = new HashSet<Consultant>();
            this.Messages = new HashSet<Message>();
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int UserId { get; set; }
        [DisplayName("���������")]
        public string nickname { get; set; }
        [DisplayName("������")]
        public string password { get; set; }
        [DisplayName("E-mail")]
        public string email { get; set; }
        [DisplayName("���")]
        public string firstname { get; set; }
        [DisplayName("�������")]
        public string lastname { get; set; }
        [DisplayName("��������")]
        public string middlename { get; set; }
        [DisplayName("�����")]
        public string street_address { get; set; }
        [DisplayName("�����")]
        public string city { get; set; }
        public Nullable<int> CountryId { get; set; }
        [DisplayName("�������� ������")]
        public string zip { get; set; }
        [DisplayName("����/�������")]
        public string state { get; set; }
        [DisplayName("�������")]
        public string phone { get; set; }
        [DisplayName("���� �������� ��������")]
        public short wants_newsletter { get; set; }
        [DisplayName("�������������� ��������")]
        public string alternate_contacts { get; set; }
        [DisplayName("�����������")]
        public string comments { get; set; }
        [DisplayName("�������� ����������� ��� �������")]
        public short can_publish_questions { get; set; }
        public int RoleId { get; set; }
    
        public virtual ICollection<Consultant> Consultants { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
