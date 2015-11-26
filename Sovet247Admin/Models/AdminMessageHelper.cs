using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof(AdminMessageHelper))]
    public partial class AdminMessage
    {
        
    }

    public partial class AdminMessageHelper
    {
        public int adminMessageId { get; set; }
        public int parentMessageId { get; set; }
        [DisplayName("Отправитель")]
        public int fromUserId { get; set; }
        [DisplayName("Получатель")]
        public int toUserId { get; set; }
        [DisplayName("Тема письма")]
        public string subject { get; set; }
        [DisplayName("Сообщение")]
        public string message { get; set; }
        [DisplayName("Дата")]
        public System.DateTime dateCreated { get; set; }
        [DisplayName("Прочитано")]
        public bool IsHasRead { get; set; }

        public virtual User FromUser { get; set; }
        public virtual User ToUser { get; set; }
    }
}