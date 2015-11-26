using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof(UserHelper))]
    public partial class User
    {
        
    }

    public partial class UserHelper
    {
        [DisplayName("Псевдоним")]
        public string nickname { get; set; }
        [DisplayName("Пароль")]
        public string password { get; set; }
        [DisplayName("E-mail")]
        public string email { get; set; }
        [DisplayName("Имя")]
        public string firstname { get; set; }
        [DisplayName("Фамилия")]
        public string lastname { get; set; }
        [DisplayName("Отчество")]
        public string middlename { get; set; }
        [DisplayName("Адрес")]
        public string street_address { get; set; }
        [DisplayName("Город")]
        public string city { get; set; }
        public Nullable<int> CountryId { get; set; }
        [DisplayName("Почтовый индекс")]
        public string zip { get; set; }
        [DisplayName("Штат/Область")]
        public string state { get; set; }
        [DisplayName("Телефон")]
        public string phone { get; set; }
        [DisplayName("Хочу получать рассылку")]
        public short wants_newsletter { get; set; }
        [DisplayName("Альтернативные контакты")]
        public string alternate_contacts { get; set; }
        [DisplayName("Комментарии")]
        public string comments { get; set; }
        [DisplayName("Разрешаю публиковать мои вопросы")]
        public short can_publish_questions { get; set; }
    }
}