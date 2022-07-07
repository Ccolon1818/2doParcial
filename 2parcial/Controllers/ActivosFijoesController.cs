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
    public class ActivosFijoesController : Controller
    {
        private ActivosFijosEntities db = new ActivosFijosEntities();

        // GET: ActivosFijoes
        public ActionResult Index()
        {
            var activosFijos = db.ActivosFijos.Include(a => a.Departamento).Include(a => a.TipoDeActivo);
            return View(activosFijos.ToList());
        }

        // GET: ActivosFijoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivosFijo activosFijo = db.ActivosFijos.Find(id);
            if (activosFijo == null)
            {
                return HttpNotFound();
            }
            return View(activosFijo);
        }

        // GET: ActivosFijoes/Create
        public ActionResult Create()
        {
            ViewBag.DepID = new SelectList(db.Departamentos, "DepID", "Descripcion");
            ViewBag.TActivoID = new SelectList(db.TipoDeActivos, "TActivoID", "Descripcion");
            return View();
        }

        // POST: ActivosFijoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AFijoID,Descripcion,DepID,TActivoID,FechaRegistro,Valor,DepreAcumulada")] ActivosFijo activosFijo)
        {
            if (ModelState.IsValid)
            {
                db.ActivosFijos.Add(activosFijo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepID = new SelectList(db.Departamentos, "DepID", "Descripcion", activosFijo.DepID);
            ViewBag.TActivoID = new SelectList(db.TipoDeActivos, "TActivoID", "Descripcion", activosFijo.TActivoID);
            return View(activosFijo);
        }

        // GET: ActivosFijoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivosFijo activosFijo = db.ActivosFijos.Find(id);
            if (activosFijo == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepID = new SelectList(db.Departamentos, "DepID", "Descripcion", activosFijo.DepID);
            ViewBag.TActivoID = new SelectList(db.TipoDeActivos, "TActivoID", "Descripcion", activosFijo.TActivoID);
            return View(activosFijo);
        }

        // POST: ActivosFijoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AFijoID,Descripcion,DepID,TActivoID,FechaRegistro,Valor,DepreAcumulada")] ActivosFijo activosFijo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activosFijo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepID = new SelectList(db.Departamentos, "DepID", "Descripcion", activosFijo.DepID);
            ViewBag.TActivoID = new SelectList(db.TipoDeActivos, "TActivoID", "Descripcion", activosFijo.TActivoID);
            return View(activosFijo);
        }

        // GET: ActivosFijoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivosFijo activosFijo = db.ActivosFijos.Find(id);
            if (activosFijo == null)
            {
                return HttpNotFound();
            }
            return View(activosFijo);
        }

        // POST: ActivosFijoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivosFijo activosFijo = db.ActivosFijos.Find(id);
            db.ActivosFijos.Remove(activosFijo);
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
