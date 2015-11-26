using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof(Consultation_TimeHelper))]
    public partial class Consultation_Time
    {
    }

    public partial class Consultation_TimeHelper
    {
        public int consultationTimeId { get; set; }
        [DisplayName("Консультация")]
        public Nullable<int> ConsultationId { get; set; }
        [DisplayName("Дата с")]
        public Nullable<System.DateTime> startTime { get; set; }
        [DisplayName("Дата по")]
        public Nullable<System.DateTime> endTime { get; set; }
        [DisplayName("Skype")]
        public string skypeContact { get; set; }
        [DisplayName("Телефон")]
        public string phoneContact { get; set; }
    }
}