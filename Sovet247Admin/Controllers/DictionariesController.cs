using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sovet247Admin.Controllers
{
    public class DictionariesController : Controller
    {
        // GET: Dictionaries
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}