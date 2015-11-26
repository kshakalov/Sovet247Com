using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sovet247Admin.Models
{
    [MetadataType(typeof (MenuHelper))]
    public partial class Menu
    {
    }

    public partial class MenuHelper
    {
        public int MenuId { get; set; }
        [DisplayName("Заголовок")]
        public string title { get; set; }
        [DisplayName("URL")]
        public string url { get; set; }
        [DisplayName("Роли пользователей")]
        public string roles { get; set; }
        [DisplayName("Родительский пункт")]
        public Nullable<int> parent_id { get; set; }
        [DisplayName("Порядок сортировки")]
        public Nullable<int> sort_order { get; set; }
    }
}