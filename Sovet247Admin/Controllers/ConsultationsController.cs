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
        public ViewResult Index(int? page, int? consultation_status_search, string customer_name_search,
            string consultant_name_search, int? specialty_search, int? consultation_type_search, string keyword_search,
            DateTime? fromdate_search, DateTime? todate_search)
        {
            if (page == null)
                page= 1;
            var consultations = _db.Consultations.Include(c => c.Consultant)
                .Include(c => c.Consultation_Statuses)
                .Include(c => c.Consultation_Types)
                .Include(c => c.Profession)
                .Include(c => c.Specialty)
                .Include(c=>c.User);
            if (consultation_status_search != null)
            {
                consultations = consultations.Where(c => c.consultation_status == consultation_status_search);
                ViewBag.consultation_status_id = consultation_status_search;
            }

            if (specialty_search != null)
            {
                consultations = consultations.Where(c => c.SpecialtyId == specialty_search);
                ViewBag.specialty_search = specialty_search;
            }

            if (consultation_type_search != null)
            {
                consultations = consultations.Where(c => c.consultation_type == consultation_type_search);
                ViewBag.consultation_type_search = consultation_type_search;
            }

            if (!String.IsNullOrEmpty(customer_name_search))
            {
                consultations = consultations.Where(c => c.User.firstname.Contains(customer_name_search) || c.User.lastname.Contains(customer_name_search));
                ViewBag.customer_name_search = customer_name_search;
            }

            if (!String.IsNullOrEmpty(keyword_search))
            {
                consultations = consultations.Where(c => c.subject.Contains(keyword_search));
                ViewBag.keyword_search = keyword_search;
            }

            if (fromdate_search != null)
            {
                consultations = consultations.Where(c => c.create_date >= fromdate_search);
                ViewBag.fromdate_search = fromdate_search;
            }
            if (todate_search != null)
            {
                consultations = consultations.Where(c => c.create_date <= todate_search);
                ViewBag.todate_search = todate_search;
            }

            if (!String.IsNullOrEmpty(consultant_name_search))
            {
                consultations = consultations.Where(c => c.Consultant.User.firstname.Contains(consultant_name_search)
                    || c.Consultant.User.lastname.Contains(consultant_name_search));
                ViewBag.consultant_name_search = consultant_name_search;
            }
            ViewBag.consultation_status_search = new SelectList(_db.Consultation_Statuses, "consultationStatusId", "status_title", ViewBag.consultation_status_id as int?);
            ViewBag.specialty_search=new SelectList(_db.Specialties, "specialtyId", "specialty_title", ViewBag.specialty_search as int?);
            ViewBag.consultation_type_search = new SelectList(_db.Consultation_Types, "ConsultationTypeId",
                "consultation_type", ViewBag.consultation_type_search as int?);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            consultations=consultations.OrderByDescending(c=>c.update_date);
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

            var messages = consultation.Messages;
            ViewBag.messages = messages;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveAdminComments([Bind(Include = "ConsultationId, admin_comments")]Consultation consultation)
        {
            Consultation cons = await _db.Consultations.FindAsync(consultation.ConsultationId);
            if (ModelState.IsValid)
            {
                if (cons == null)
                {
                    return HttpNotFound();
                }
                cons.admin_comments=consultation.admin_comments;
                _db.Entry(cons).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Details", new { id=consultation.ConsultationId});
            }
            return View(cons);
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
