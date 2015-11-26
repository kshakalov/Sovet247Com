using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof (RoleHelper))]
    public partial class Role
    {
    }

    public partial class RoleHelper
    {
        [DisplayName("Роль")]
        public string role_title { get; set; }
    }
}