using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof(CountryHelper))]
    public partial class Country
    {
        
    }

    public partial class CountryHelper
    {
        public int CountryId { get; set; }
        [DisplayName("Код страны")]
        public string country_code { get; set; }
        [DisplayName("Страна")]
        public string country_name { get; set; }
    }
}