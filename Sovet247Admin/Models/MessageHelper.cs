using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof (MessageHelper))]
    public partial class Message
    {
    }

    public partial class MessageHelper
    {
        public int MessageId { get; set; }
        [DisplayName("Консультация")]
        public Nullable<int> ConsultationId { get; set; }
        [DisplayName("Сообщение")]
        public string message1 { get; set; }
        [DisplayName("Дата")]
        public Nullable<System.DateTime> added_date { get; set; }
        [DisplayName("Вложения")]
        public string attachment { get; set; }
        [DisplayName("Автор")]
        public Nullable<int> UserId { get; set; }
        [DisplayName("Опубликовано")]
        public byte published { get; set; }
    }
}