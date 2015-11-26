using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof(ConsultationStatusHelper))]
    public partial class Consultation_Statuses
    {
        
    }
    public partial class ConsultationStatusHelper
    {
        public int ConsultationStatusId { get; set; }
        [DisplayName("Статус консультации")]
        public string status_title { get; set; }
    }
}