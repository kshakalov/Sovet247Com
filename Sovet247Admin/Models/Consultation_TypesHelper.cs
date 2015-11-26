using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof(Consultation_TypesHelper))]
    public partial class Consultation_Types
    {
    }

    public partial class Consultation_TypesHelper
    {
        public int ConsultationTypeId { get; set; }
        [DisplayName("Тип консультации")]
        public string consultation_type { get; set; }
        [DisplayName("Активен")]
        public byte active { get; set; }
    }
}