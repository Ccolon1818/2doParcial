using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2parcial;

namespace _2parcial.Controllers
{
    public class TipoDeActivoesController : Controller
    {
        private ActivosFijosEntities db = new ActivosFijosEntities();

        // GET: TipoDeActivoes
        public ActionResult Index()
        {
            return View(db.TipoDeActivos.ToList());
        }

        // GET: TipoDeActivoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeActivo tipoDeActivo = db.TipoDeActivos.Find(id);
            if (tipoDeActivo == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeActivo);
        }

        // GET: TipoDeActivoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeActivoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TActivoID,Descripcion,CCCompra,CCDepreciacion,Estado")] TipoDeActivo tipoDeActivo)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeActivos.Add(tipoDeActivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDeActivo);
        }

        // GET: TipoDeActivoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeActivo tipoDeActivo = db.TipoDeActivos.Find(id);
            if (tipoDeActivo == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeActivo);
        }

        // POST: TipoDeActivoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TActivoID,Descripcion,CCCompra,CCDepreciacion,Estado")] TipoDeActivo tipoDeActivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeActivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDeActivo);
        }

        // GET: TipoDeActivoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeActivo tipoDeActivo = db.TipoDeActivos.Find(id);
            if (tipoDeActivo == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeActivo);
        }

        // POST: TipoDeActivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeActivo tipoDeActivo = db.TipoDeActivos.Find(id);
            db.TipoDeActivos.Remove(tipoDeActivo);
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
