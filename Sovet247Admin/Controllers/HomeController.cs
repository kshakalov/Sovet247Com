using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sovet247Admin.Models;

namespace Sovet247Admin.Controllers
{
    [Authorize(Roles = "Администратор")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ConsultationsDbContext _context=new ConsultationsDbContext();
            var roleId=_context.Users.FirstOrDefault(u=>u.email==User.Identity.Name).RoleId;
            ViewBag.Menu = _context.Menus.Where(m=>m.roles.Contains(roleId.ToString())).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}