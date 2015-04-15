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
    [Authorize(Roles = "Администратор")]
    public class SpecialtiesController : Controller
    {
        private ConsultationsDbContext db = new ConsultationsDbContext();

        // GET: Specialties
        public async Task<ActionResult> Index()
        {
            var specialties = db.Specialties.Include(s => s.Profession);
            return View(await specialties.ToListAsync());
        }

        // GET: Specialties/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialty specialty = await db.Specialties.FindAsync(id);
            if (specialty == null)
            {
                return HttpNotFound();
            }
            return View(specialty);
        }

        // GET: Specialties/Create
        public ActionResult Create()
        {
            ViewBag.ProfessionId = new SelectList(db.Professions, "ProfessionId", "Profession_Title");
            return View();
        }

        // POST: Specialties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SpecialtyId,Specialty_title,ProfessionId,active")] Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                db.Specialties.Add(specialty);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProfessionId = new SelectList(db.Professions, "ProfessionId", "Profession_Title", specialty.ProfessionId);
            return View(specialty);
        }

        // GET: Specialties/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialty specialty = await db.Specialties.FindAsync(id);
            if (specialty == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfessionId = new SelectList(db.Professions, "ProfessionId", "Profession_Title", specialty.ProfessionId);
            return View(specialty);
        }

        // POST: Specialties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SpecialtyId,Specialty_title,ProfessionId,active")] Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialty).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProfessionId = new SelectList(db.Professions, "ProfessionId", "Profession_Title", specialty.ProfessionId);
            return View(specialty);
        }

        // GET: Specialties/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialty specialty = await db.Specialties.FindAsync(id);
            if (specialty == null)
            {
                return HttpNotFound();
            }
            return View(specialty);
        }

        // POST: Specialties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Specialty specialty = await db.Specialties.FindAsync(id);
            db.Specialties.Remove(specialty);
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
