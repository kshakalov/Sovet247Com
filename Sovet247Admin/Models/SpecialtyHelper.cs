using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof (SpecialtyHelper))]
    public partial class Specialty
    {
    }

    public partial class SpecialtyHelper
    {
        public int SpecialtyId { get; set; }
        [DisplayName("Специальность")]
        public string Specialty_title { get; set; }
        [DisplayName("Профессия")]
        public int ProfessionId { get; set; }
        [DisplayName("Активна")]
        public bool active { get; set; }
    }
}