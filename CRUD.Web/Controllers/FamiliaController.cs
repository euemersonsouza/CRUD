using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CRUD.Model
{
    public class FamiliaController : Controller
    {
        private CRUDContext db = new CRUDContext();

        // GET: Familia
        public ActionResult Index()
        {
            return View(db.Familia.ToList());
        }

        // GET: Familia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familia famModel = db.Familia.Find(id);
            if (famModel == null)
            {
                return HttpNotFound();
            }
            return View(famModel);
        }

        // GET: Familia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Familia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Familia famModel)
        {
            if (ModelState.IsValid)
            {
                db.Familia.Add(famModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(famModel);
        }

        // GET: Familia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familia fam = db.Familia.Find(id);
            if (fam == null)
            {
                return HttpNotFound();
            }
            return View(fam);
        }

        // POST: Familia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Familia fam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fam);
        }

        // GET: Familia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominio cond = db.Codominio.Find(id);
            if (cond == null)
            {
                return HttpNotFound();
            }
            return View(cond);
        }

        // POST: Familia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Familia fam = db.Familia.Find(id);
            db.Familia.Remove(fam);
            db.SaveChanges();
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
