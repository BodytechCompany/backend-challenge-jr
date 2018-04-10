using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BtTraining.Models;
using BusinessLibrary.Entity;

namespace BT.Areas.Professor.Controllers
{
    public class ExerciciosController : Controller
    {
        private BTContext db = new BTContext();

        // GET: Professor/Exercicios
        public ActionResult Index()
        {
            var exercicios = db.Exercicios.Include(e => e.Cliente).Include(e => e.professor);
            return View(exercicios.ToList());
        }

        // GET: Professor/Exercicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicios.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            return View(exercicio);
        }

        // GET: Professor/Exercicios/Create
        public ActionResult Create()
        {
            ViewBag.clie_id = new SelectList(db.Clientes, "clie_id", "clie_nm_nome");
            ViewBag.prof_id = new SelectList(db.Professors, "prof_id", "prof_nm_nome");
            return View();
        }

        // POST: Professor/Exercicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Exer_id,exer_nr_ordem,clie_id,exer_nm_nome,exer_nm_repeticao,exer_db_carga,prof_id")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                db.Exercicios.Add(exercicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clie_id = new SelectList(db.Clientes, "clie_id", "clie_nm_nome", exercicio.clie_id);
            ViewBag.prof_id = new SelectList(db.Professors, "prof_id", "prof_nm_nome", exercicio.prof_id);
            return View(exercicio);
        }

        // GET: Professor/Exercicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicios.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.clie_id = new SelectList(db.Clientes, "clie_id", "clie_nm_nome", exercicio.clie_id);
            ViewBag.prof_id = new SelectList(db.Professors, "prof_id", "prof_nm_nome", exercicio.prof_id);
            return View(exercicio);
        }

        // POST: Professor/Exercicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Exer_id,exer_nr_ordem,clie_id,exer_nm_nome,exer_nm_repeticao,exer_db_carga,prof_id")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clie_id = new SelectList(db.Clientes, "clie_id", "clie_nm_nome", exercicio.clie_id);
            ViewBag.prof_id = new SelectList(db.Professors, "prof_id", "prof_nm_nome", exercicio.prof_id);
            return View(exercicio);
        }

        // GET: Professor/Exercicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicios.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            return View(exercicio);
        }

        // POST: Professor/Exercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercicio exercicio = db.Exercicios.Find(id);
            db.Exercicios.Remove(exercicio);
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
