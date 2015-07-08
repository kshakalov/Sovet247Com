using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sovet247Admin.Models;
using Microsoft.AspNet.Identity;

namespace Sovet247Admin.Controllers
{
    [Authorize(Roles = "Администратор")]
    public class AdminMessagesController : Controller
    {
        private ConsultationsDbContext db = new ConsultationsDbContext();

        // GET: AdminMessages
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var adminMessages = db.AdminMessages.Where(am=>(am.parentMessageId==0) && (am.toUserId==0 || am.fromUserId==userId || am.toUserId==userId)).Include(u=>u.FromUser).Include(u2=>u2.ToUser);
                        
            return View(await adminMessages.OrderByDescending(ord=>ord.dateCreated).ToListAsync());
        }

        // GET: AdminMessages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminMessage adminMessage = await db.AdminMessages.FindAsync(id);
            if (adminMessage == null)
            {
                return HttpNotFound();
            }

            var childMessages = db.AdminMessages.Where(wh => wh.parentMessageId == id);
            ViewBag.childMessages = childMessages;
            return View(adminMessage);
        }

      

        public ActionResult Answer(string parentMessageId)
        {
            var parentId=(!String.IsNullOrEmpty(Request["parentMessageId"]))?Int32.Parse(Request["parentMessageId"]):0;
            var message = db.AdminMessages.Where(wh => wh.adminMessageId == parentId).FirstOrDefault();
            ViewBag.parentMessageId = parentId;
            ViewBag.fromUserId = User.Identity.GetUserId<int>();
            ViewBag.toUserId = message.fromUserId;
            ViewBag.subject = message.subject;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Answer([Bind(Include = "parentMessageId,fromUserId,toUserId,subject,message")] AdminMessage adminMessage)
        {
            if (ModelState.IsValid)
            {
                adminMessage.dateCreated = DateTime.Now;
                adminMessage.IsHasRead = false;
                db.AdminMessages.Add(adminMessage);
                //await db.SaveChangesAsync();
                
                //Set status unread
                var oldMessage = db.AdminMessages.Where(wh => wh.adminMessageId == adminMessage.parentMessageId).FirstOrDefault();
                oldMessage.IsHasRead = false;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var parentId = adminMessage.parentMessageId;
            var message = db.AdminMessages.Where(wh => wh.adminMessageId == parentId).FirstOrDefault();
            ViewBag.parentMessageId = parentId;
            ViewBag.fromUserId = User.Identity.GetUserId<int>();
            ViewBag.toUserId = message.fromUserId;
            ViewBag.subject = message.subject;
            return View(adminMessage);
        }


        // GET: AdminMessages/Create
        public ActionResult Create()
        {
            ViewBag.fromUserId = User.Identity.GetUserId<int>();
            ViewBag.ToUserIdSelectList = new SelectList(db.Users, "UserId", "email");
            return View();
        }


        // POST: AdminMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "adminMessageId,fromUserId,toUserId,subject,message")] AdminMessage adminMessage)
        {
            if (ModelState.IsValid)
            {
                adminMessage.dateCreated = DateTime.Now;
                adminMessage.IsHasRead = false;
                adminMessage.parentMessageId = 0;
                db.AdminMessages.Add(adminMessage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.fromUserId = User.Identity.GetUserId<int>();
            ViewBag.ToUserIdSelectList = new SelectList(db.Users, "UserId", "email");
            return View(adminMessage);
        }

     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
