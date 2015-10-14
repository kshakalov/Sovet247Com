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
using PagedList;

namespace Sovet247Admin.Controllers
{
    [Authorize(Roles="Администратор")]
    public class TransactionsController : Controller
    {
        private readonly ConsultationsDbContext _db = new ConsultationsDbContext();

        // GET: Transactions
        public ViewResult Index(int? page, int? userId, int? transactionTypeSearch, string userNameSearch, 
            DateTime? fromDateSearch, DateTime? toDateSearch)
        {
            if (page == null)
                page = 1;
            
            var transactions = _db.Transactions.Include(t => t.Consultation).Include(t => t.User);

            if (userId != null)
            {
                transactions = transactions.Where(t => t.UserId == userId);
                ViewBag.userIdSearch = userId;
            }

            if (transactionTypeSearch != null)
            {
                switch (transactionTypeSearch)
                {
                    case 1:
                        transactions = transactions.Where(t => t.amount < 0);
                        break;
                    default:
                        transactions = transactions.Where(t => t.amount >= 0);
                        break;
                }
            }

            if (!String.IsNullOrEmpty(userNameSearch))
            {
                transactions =
                    transactions.Where(
                        t => t.User.firstname.Contains(userNameSearch) || t.User.lastname.Contains(userNameSearch));
                ViewBag.userNameSearch = userNameSearch;
            }

            if (fromDateSearch != null)
            {
                transactions = transactions.Where(t => t.transactionDate >= fromDateSearch);
                ViewBag.fromDateSearch = fromDateSearch;
            }
            if (toDateSearch != null)
            {
                transactions = transactions.Where(t => t.transactionDate <= toDateSearch);
                ViewBag.toDateSearch = toDateSearch;
            }

            ViewBag.transactionTypeSearch =
                new SelectList(new[]
                {
                    new SelectListItem{Text= "Расходы", Value="1", Selected=(transactionTypeSearch==1)},
                    new SelectListItem {Text="Доходы", Value="2", Selected = (transactionTypeSearch==2)}
                },"Value", "Text",transactionTypeSearch);

            transactions = transactions.OrderByDescending(t => t.transactionDate);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(transactions.ToPagedList(pageNumber, pageSize));
        }

        // GET: Transactions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await _db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            ViewBag.ConsultationId = new SelectList(_db.Consultations, "ConsultationId", "subject");
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "nickname");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TransactionId,UserId,amount,transactionDate,description,ConsultationId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Transactions.Add(transaction);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ConsultationId = new SelectList(_db.Consultations, "ConsultationId", "subject", transaction.ConsultationId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "nickname", transaction.UserId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await _db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConsultationId = new SelectList(_db.Consultations, "ConsultationId", "subject", transaction.ConsultationId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "nickname", transaction.UserId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TransactionId,UserId,amount,transactionDate,description,ConsultationId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(transaction).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ConsultationId = new SelectList(_db.Consultations, "ConsultationId", "subject", transaction.ConsultationId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "nickname", transaction.UserId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await _db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Transaction transaction = await _db.Transactions.FindAsync(id);
            _db.Transactions.Remove(transaction);
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
