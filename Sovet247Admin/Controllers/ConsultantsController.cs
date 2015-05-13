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

namespace Sovet247Admin.Controllers
{
    [Authorize(Roles="Администратор")]
    public class ConsultantsController : Controller
    {
        private ConsultationsDbContext db = new ConsultationsDbContext();
        
        // GET: Consultants
        public async Task<ActionResult> Index(string searchConsultantName)
        {
            var consultants = db.Consultants.Include(c => c.User).Include(c => c.Profession).Include(c=>c.Specialty);
            if(!String.IsNullOrEmpty(searchConsultantName))
            {
                consultants = consultants.Where(c => c.User.firstname.Contains(searchConsultantName)
                    || c.User.lastname.Contains(searchConsultantName));
            }
            return View(await consultants.ToListAsync());
        }

        // GET: Consultants/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            return View(consultant);
        }

        // GET: Consultants/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "nickname");
            ViewBag.ProfessionId = new SelectList(db.Professions, "ProfessionId", "Profession_Title");
            ViewBag.SpecialtyId = new SelectList(db.Specialties, "SpecialtyId", "Specialty_Title");
            return View();
        }

        // POST: Consultants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ConsultantId,ProfessionId,SpecialtyId,specialization,UserId,education,workplace,active,short_resume,comission_percent,photo_url")] Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                db.Consultants.Add(consultant);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "nickname", consultant.UserId);
            ViewBag.ProfessionId = new SelectList(db.Professions, "ProfessionId", "Profession_Title", consultant.ProfessionId);
            ViewBag.SpecialtyId = new SelectList(db.Specialties.Where(p => p.ProfessionId == consultant.ProfessionId), "SpecialtyId", "Specialty_Title", consultant.SpecialtyId);
            return View(consultant);
        }

        // GET: Consultants/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "lastname", consultant.UserId);
            TempData["tmpProfessionId"]=consultant.ProfessionId;
            ViewBag.ProfessionId = new SelectList(db.Professions, "ProfessionId", "Profession_Title", consultant.ProfessionId);
            ViewBag.SpecialtyId = new SelectList(db.Specialties.Where(p=>p.ProfessionId==consultant.ProfessionId), "SpecialtyId", "Specialty_Title", consultant.SpecialtyId);
            return View(consultant);
        }

        // POST: Consultants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ConsultantId,ProfessionId,SpecialtyId,specialization,UserId,education,workplace,active,short_resume,comission_percent,photo_url, tmpProfessionId")] Consultant consultant)
        {
            if (ModelState.IsValid && consultant.ProfessionId == (int?)TempData["tmpProfessionId"])
            {
                db.Entry(consultant).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "nickname", consultant.UserId);
            ViewBag.ProfessionId = new SelectList(db.Professions, "ProfessionId", "Profession_Title", consultant.ProfessionId);
            ViewBag.SpecialtyId = new SelectList(db.Specialties.Where(p => p.ProfessionId == consultant.ProfessionId), "SpecialtyId", "Specialty_Title", consultant.SpecialtyId);
            TempData["tmpProfessionId"] = consultant.ProfessionId;
            return View(consultant);
        }

        // GET: Consultants/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            return View(consultant);
        }

        // POST: Consultants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Consultant consultant = await db.Consultants.FindAsync(id);
            db.Consultants.Remove(consultant);
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
