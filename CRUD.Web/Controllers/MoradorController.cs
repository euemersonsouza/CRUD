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
    public class MoradorController : Controller
    {
        private CRUDContext db = new CRUDContext();

        // GET: Morador
        public ActionResult Index()
        {
            return View(db.Morador.ToList());
        }

        // GET: Morador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador morModel = db.Morador.Find(id);
            if (morModel == null)
            {
                return HttpNotFound();
            }
            return View(morModel);
        }

        // GET: Morador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Morador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Morador morModel)
        {
            if (ModelState.IsValid)
            {
                db.Morador.Add(morModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(morModel);
        }

        // GET: Morador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador mor = db.Morador.Find(id);
            if (mor == null)
            {
                return HttpNotFound();
            }
            return View(mor);
        }

        // POST: Morador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Morador mor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mor);
        }

        // GET: Morador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador mora = db.Morador.Find(id);
            if (mora == null)
            {
                return HttpNotFound();
            }
            return View(mora);
        }

        // POST: Morador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Morador mora = db.Morador.Find(id);
            db.Morador.Remove(mora);
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
