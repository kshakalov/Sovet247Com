using System.Web.Mvc;

namespace Sovet247Admin.Controllers
{
    public class DictionariesController : Controller
    {
        // GET: Dictionaries
        [Authorize(Roles="Администратор")]
        public ActionResult Index()
        {
            return View();
        }
    }
}