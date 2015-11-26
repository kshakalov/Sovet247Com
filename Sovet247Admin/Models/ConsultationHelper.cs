using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof(ConsultationHelper))]
    public partial class Consultation
    {
        
    }

    public partial class ConsultationHelper
    {
        public int ConsultationId { get; set; }
        [DisplayName("Клиент")]
        public int UserId { get; set; }
        [DisplayName("Консультант")]
        public Nullable<int> ConsultantId { get; set; }
        [DisplayName("Вопрос")]
        public string subject { get; set; }
        [DisplayName("Тип консультации")]
        public int consultation_type { get; set; }
        [DisplayName("Профессия")]
        public int ProfessionId { get; set; }
        [DisplayName("Специальность")]
        public Nullable<int> SpecialtyId { get; set; }
        [DisplayName("Статус")]
        public int consultation_status { get; set; }
        [DisplayName("Дата")]
        public System.DateTime create_date { get; set; }
        [DisplayName("Дата обновления")]
        public System.DateTime update_date { get; set; }
        [DisplayName("Рейтинг")]
        public Nullable<decimal> customer_rating { get; set; }
        [DisplayName("Комментарий")]
        public string customer_comments { get; set; }
        [DisplayName("Стоимость вопроса")]
        public decimal consultation_price { get; set; }
        [DisplayName("Комментарий администратора")]
        public string admin_comments { get; set; }
        [DisplayName("Срочность")]
        public short urgency { get; set; }
        [DisplayName("Детализация")]
        public short detalization { get; set; }
    }
}
