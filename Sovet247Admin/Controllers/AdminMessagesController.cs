using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Sovet247Admin.Models;

namespace Sovet247Admin.Controllers
{
    [Authorize(Roles = "Администратор")]
    public class AdminMessagesController : Controller
    {
        private readonly ConsultationsDbContext _db = new ConsultationsDbContext();

        // GET: AdminMessages
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var adminMessages = _db.AdminMessages.Where(am=>(am.parentMessageId==0) && (am.toUserId==0 || am.fromUserId==userId || am.toUserId==userId)).Include(u=>u.FromUser).DefaultIfEmpty().Include(u2=>u2.ToUser).DefaultIfEmpty();
                        
            return View(await adminMessages.OrderByDescending(ord=>ord.dateCreated).ToListAsync());
        }

        // GET: AdminMessages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminMessage adminMessage = await _db.AdminMessages.FindAsync(id);
            if (adminMessage == null)
            {
                return HttpNotFound();
            }

            var childMessages = _db.AdminMessages.Where(wh => wh.parentMessageId == id).OrderByDescending(or=>or.dateCreated);
            ViewBag.childMessages=childMessages.ToList<AdminMessage>();
            //TempData.Keep();
            return View(adminMessage);
        }

      

        public ActionResult Answer(string parentMessageId)
        {
            var parentId=(!String.IsNullOrEmpty(Request["parentMessageId"]))?Int32.Parse(Request["parentMessageId"]):0;
            var message = _db.AdminMessages.FirstOrDefault(wh => wh.adminMessageId == parentId);
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
                _db.AdminMessages.Add(adminMessage);
                //await db.SaveChangesAsync();
                
                //Set status unread
                var oldMessage = _db.AdminMessages.FirstOrDefault(wh => wh.adminMessageId == adminMessage.parentMessageId);
                oldMessage.IsHasRead = false;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var parentId = adminMessage.parentMessageId;
            var message = _db.AdminMessages.FirstOrDefault(wh => wh.adminMessageId == parentId);
            ViewBag.parentMessageId = parentId;
            ViewBag.fromUserId = User.Identity.GetUserId<int>();
            ViewBag.toUserId = message.fromUserId;
            ViewBag.subject = message.subject;
            return View(adminMessage);
        }


        // GET: AdminMessages/Create
        public ActionResult Create(int? id)
        {
            ViewBag.fromUserId = User.Identity.GetUserId<int>();
            if (id != null)
            {
                var toUser=_db.Consultants.Find(id).User.email;
                var list=new SelectList(new[]{toUser});

                ViewBag.ToUserIdSelectList = list;
            }
            else
            {
                ViewBag.ToUserIdSelectList = new SelectList(_db.Users, "UserId", "email");
            }
            
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
                _db.AdminMessages.Add(adminMessage);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.fromUserId = User.Identity.GetUserId<int>();
            ViewBag.ToUserIdSelectList = new SelectList(_db.Users, "UserId", "email");
            return View(adminMessage);
        }

     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
