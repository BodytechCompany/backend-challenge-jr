using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BT.Models;
using BtTraining.Models;

namespace BT.Areas.Management.Controllers
{
    public class LoginsController : Controller
    {
        private BTContext db = new BTContext();

        // GET: Management/Logins
        public ActionResult Index()
        {
            var logins = db.Logins.Include(l => l.tipoMatricula);
            return View(logins.ToList());
        }

        // GET: Management/Logins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // GET: Management/Logins/Create
        public ActionResult Create()
        {
            ViewBag.TipoMatricula_id = new SelectList(db.TipoMatriculas, "TipoMatricula_id", "Descricao");
            return View();
        }

        // POST: Management/Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Matricula_Usuario,Senha,TipoMatricula_id")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoMatricula_id = new SelectList(db.TipoMatriculas, "TipoMatricula_id", "Descricao", login.TipoMatricula_id);
            return View(login);
        }

        // GET: Management/Logins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoMatricula_id = new SelectList(db.TipoMatriculas, "TipoMatricula_id", "Descricao", login.TipoMatricula_id);
            return View(login);
        }

        // POST: Management/Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Matricula_Usuario,Senha,TipoMatricula_id")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoMatricula_id = new SelectList(db.TipoMatriculas, "TipoMatricula_id", "Descricao", login.TipoMatricula_id);
            return View(login);
        }

        // GET: Management/Logins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Management/Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login login = db.Logins.Find(id);
            db.Logins.Remove(login);
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
