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
    
    public partial class AdminMessage
    {
        public int adminMessageId { get; set; }
        public int parentMessageId { get; set; }
        [DisplayName("�����������")]
        public int fromUserId { get; set; }
        [DisplayName("����������")]
        public int toUserId { get; set; }
        [DisplayName("���� ���������")]
        public string subject { get; set; }
        [DisplayName("����� ���������")]
        public string message { get; set; }
        [DisplayName("����")]
        public System.DateTime dateCreated { get; set; }
        public bool IsHasRead { get; set; }
    
        public virtual User FromUser { get; set; }
        public virtual User ToUser { get; set; }
    }
}
