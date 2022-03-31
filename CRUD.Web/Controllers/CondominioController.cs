using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD;
using CRUD.Model;

namespace CRUD.Web.Controllers
{
    public class CondominioController : Controller
    {
        private CRUDContext db = new CRUDContext();

        // GET: Condominio
        public ActionResult Index()
        {
            return View(db.Codominio.ToList());
        }

        // GET: Condominio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominio alunoModel = db.Codominio.Find(id);
            if (alunoModel == null)
            {
                return HttpNotFound();
            }
            return View(alunoModel);
        }

        // GET: Condominio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Condominio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nome,Bairro")] Condominio alunoModel)
        {
            if (ModelState.IsValid)
            {
                db.Codominio.Add(alunoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alunoModel);
        }

        // GET: Condominio/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Condominio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nome,Bairro")] Condominio cond)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cond).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cond);
        }

        // GET: Condominio/Delete/5
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

        // POST: Condominio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Condominio cond = db.Codominio.Find(id);
            db.Codominio.Remove(cond);
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
