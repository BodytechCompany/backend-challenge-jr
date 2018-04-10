using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLibrary.Entity;
using BtTraining.Models;

namespace BT.Areas.Management.Controllers
{
    public class TipoMatriculasController : Controller
    {
        private BTContext db = new BTContext();

        // GET: Management/TipoMatriculas
        public ActionResult Index()
        {
            return View(db.TipoMatriculas.ToList());
        }

        // GET: Management/TipoMatriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMatricula tipoMatricula = db.TipoMatriculas.Find(id);
            if (tipoMatricula == null)
            {
                return HttpNotFound();
            }
            return View(tipoMatricula);
        }

        // GET: Management/TipoMatriculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Management/TipoMatriculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoMatricula_id,Descricao")] TipoMatricula tipoMatricula)
        {
            if (ModelState.IsValid)
            {
                db.TipoMatriculas.Add(tipoMatricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoMatricula);
        }

        // GET: Management/TipoMatriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMatricula tipoMatricula = db.TipoMatriculas.Find(id);
            if (tipoMatricula == null)
            {
                return HttpNotFound();
            }
            return View(tipoMatricula);
        }

        // POST: Management/TipoMatriculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoMatricula_id,Descricao")] TipoMatricula tipoMatricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoMatricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoMatricula);
        }

        // GET: Management/TipoMatriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMatricula tipoMatricula = db.TipoMatriculas.Find(id);
            if (tipoMatricula == null)
            {
                return HttpNotFound();
            }
            return View(tipoMatricula);
        }

        // POST: Management/TipoMatriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoMatricula tipoMatricula = db.TipoMatriculas.Find(id);
            db.TipoMatriculas.Remove(tipoMatricula);
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
