using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Sovet247Admin.Models;

namespace Sovet247Admin.Views
{
    [Authorize(Roles = "Администратор")]
    public class ProfessionsController : Controller
    {
        
        private readonly ConsultationsDbContext _db = new ConsultationsDbContext();

        // GET: Professions
        public async Task<ActionResult> Index()
        {
            return View(await _db.Professions.ToListAsync());
        }

        // GET: Professions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = await _db.Professions.FindAsync(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // GET: Professions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProfessionId,Profession_Title,Active")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                _db.Professions.Add(profession);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(profession);
        }

        // GET: Professions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = await _db.Professions.FindAsync(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // POST: Professions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProfessionId,Profession_Title,Active")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(profession).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(profession);
        }

        // GET: Professions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = await _db.Professions.FindAsync(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // POST: Professions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Profession profession = await _db.Professions.FindAsync(id);
            _db.Professions.Remove(profession);
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
