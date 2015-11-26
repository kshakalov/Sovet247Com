using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof(ProfessionHelper))]
    public partial class Profession { }
    
    public partial class ProfessionHelper
    {
        public int ProfessionId { get; set; }
        [DisplayName("Профессия")]
        public string Profession_Title { get; set; }
        [DisplayName("Активна")]
        public bool Active { get; set; }
    }
}