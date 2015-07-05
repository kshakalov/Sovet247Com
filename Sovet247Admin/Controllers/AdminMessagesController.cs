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
            var adminMessages = db.AdminMessages.Where(am=>am.toUserId==0 || am.fromUserId==userId || am.toUserId==userId).Include(a => a.AdminMessage1);
            return View(await adminMessages.ToListAsync());
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
            return View(adminMessage);
        }

        // GET: AdminMessages/Create
        public ActionResult Create()
        {
            ViewBag.parentMessageId = new SelectList(db.AdminMessages, "adminMessageId", "subject");
            return View();
        }

        // POST: AdminMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "adminMessageId,parentMessageId,fromUserId,toUserId,subject,message,dateCreated")] AdminMessage adminMessage)
        {
            if (ModelState.IsValid)
            {
                db.AdminMessages.Add(adminMessage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.parentMessageId = new SelectList(db.AdminMessages, "adminMessageId", "subject", adminMessage.parentMessageId);
            return View(adminMessage);
        }

        // GET: AdminMessages/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
            ViewBag.parentMessageId = new SelectList(db.AdminMessages, "adminMessageId", "subject", adminMessage.parentMessageId);
            return View(adminMessage);
        }

        // POST: AdminMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "adminMessageId,parentMessageId,fromUserId,toUserId,subject,message,dateCreated")] AdminMessage adminMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminMessage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.parentMessageId = new SelectList(db.AdminMessages, "adminMessageId", "subject", adminMessage.parentMessageId);
            return View(adminMessage);
        }

        // GET: AdminMessages/Delete/5
        public async Task<ActionResult> Delete(int? id)
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
            return View(adminMessage);
        }

        // POST: AdminMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AdminMessage adminMessage = await db.AdminMessages.FindAsync(id);
            db.AdminMessages.Remove(adminMessage);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
