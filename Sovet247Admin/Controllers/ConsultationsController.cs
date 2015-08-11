using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Sovet247Admin.Models;
using PagedList;

namespace Sovet247Admin.Controllers
{
    [Authorize(Roles="Администратор")]
    public class ConsultationsController : Controller
    {
        private readonly ConsultationsDbContext _db = new ConsultationsDbContext();

        // GET: Consultations
        public ViewResult Index(int? page)
        {
            if (page == null)
                page= 1;
            var consultations = _db.Consultations.Include(c => c.Consultant)
                .Include(c => c.Consultation_Statuses)
                .Include(c => c.Consultation_Types)
                .Include(c => c.Profession)
                .Include(c => c.Specialty)
                .Include(c=>c.User)
                .OrderByDescending(cos=>cos.update_date);
            
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(consultations.ToPagedList(pageNumber, pageSize));
        }

        // GET: Consultations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = await _db.Consultations.FindAsync(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            return View(consultation);
        }

        // GET: Consultations/Create
        public ActionResult Create()
        {
            ViewBag.ConsultantId = new SelectList(_db.Consultants, "ConsultantId", "specialization");
            ViewBag.consultation_status = new SelectList(_db.Consultation_Statuses, "ConsultationStatusId", "status_title");
            ViewBag.consultation_type = new SelectList(_db.Consultation_Types, "ConsultationTypeId", "consultation_type");
            ViewBag.ProfessionId = new SelectList(_db.Professions, "ProfessionId", "Profession_Title");
            ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Specialty_title");
            return View();
        }

        // POST: Consultations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ConsultationId,UserId,ConsultantId,subject,consultation_type,ProfessionId,SpecialtyId,consultation_status,create_date,update_date,customer_rating,customer_comments,consultation_price")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                _db.Consultations.Add(consultation);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ConsultantId = new SelectList(_db.Consultants, "ConsultantId", "specialization", consultation.ConsultantId);
            ViewBag.consultation_status = new SelectList(_db.Consultation_Statuses, "ConsultationStatusId", "status_title", consultation.consultation_status);
            ViewBag.consultation_type = new SelectList(_db.Consultation_Types, "ConsultationTypeId", "consultation_type", consultation.consultation_type);
            ViewBag.ProfessionId = new SelectList(_db.Professions, "ProfessionId", "Profession_Title", consultation.ProfessionId);
            ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Specialty_title", consultation.SpecialtyId);
            return View(consultation);
        }

        // GET: Consultations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = await _db.Consultations.FindAsync(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConsultantId = new SelectList(_db.Consultants, "ConsultantId", "specialization", consultation.ConsultantId);
            ViewBag.consultation_status = new SelectList(_db.Consultation_Statuses, "ConsultationStatusId", "status_title", consultation.consultation_status);
            ViewBag.consultation_type = new SelectList(_db.Consultation_Types, "ConsultationTypeId", "consultation_type", consultation.consultation_type);
            ViewBag.ProfessionId = new SelectList(_db.Professions, "ProfessionId", "Profession_Title", consultation.ProfessionId);
            ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Specialty_title", consultation.SpecialtyId);
            return View(consultation);
        }

        // POST: Consultations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ConsultationId,UserId,ConsultantId,subject,consultation_type,ProfessionId,SpecialtyId,consultation_status,create_date,update_date,customer_rating,customer_comments,consultation_price")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(consultation).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ConsultantId = new SelectList(_db.Consultants, "ConsultantId", "specialization", consultation.ConsultantId);
            ViewBag.consultation_status = new SelectList(_db.Consultation_Statuses, "ConsultationStatusId", "status_title", consultation.consultation_status);
            ViewBag.consultation_type = new SelectList(_db.Consultation_Types, "ConsultationTypeId", "consultation_type", consultation.consultation_type);
            ViewBag.ProfessionId = new SelectList(_db.Professions, "ProfessionId", "Profession_Title", consultation.ProfessionId);
            ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Specialty_title", consultation.SpecialtyId);
            return View(consultation);
        }

        // GET: Consultations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = await _db.Consultations.FindAsync(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            return View(consultation);
        }

        // POST: Consultations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Consultation consultation = await _db.Consultations.FindAsync(id);
            _db.Consultations.Remove(consultation);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
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
