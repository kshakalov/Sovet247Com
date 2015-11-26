using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof (ConsultantHelper))]
    public partial class Consultant
    {
        
    }

    public partial class ConsultantHelper
    {
        public int ConsultantId { get; set; }
        [DisplayName("Профессия")]
        public int ProfessionId { get; set; }
        [DisplayName("Специальность")]
        public Nullable<int> SpecialtyId { get; set; }
        [DisplayName("Специализация")]
        public string specialization { get; set; }
        [DisplayName("Пользователь")]
        public int UserId { get; set; }
        [DisplayName("Образование")]
        public string education { get; set; }
        [DisplayName("Место работы")]
        public string workplace { get; set; }
        [DisplayName("Активен")]
        public bool active { get; set; }
        [DisplayName("Краткое резюме")]
        public string short_resume { get; set; }
        [DisplayName("Процент комиссии")]
        public Nullable<decimal> comission_percent { get; set; }
        [DisplayName("Фотография")]
        public string photo_url { get; set; }
        [DisplayName("Комментарии администратора")]
        public string admin_comments { get; set; }
    }
}