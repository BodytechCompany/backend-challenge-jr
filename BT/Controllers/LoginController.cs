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

namespace BT.Controllers
{
    public class LoginController : Controller
    {
        private BTContext db = new BTContext();

        // GET: Logins
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                if (Session["tipoMatriculaLogado"].ToString() == "Professor")
                {
                    return RedirectToAction("Professor/Home");
                }
                else if (Session["tipoMatriculaLogado"].ToString() == "Cliente")
                {
                    return RedirectToAction("Cliente/Home");
                }
                return View();
            }
            else
            {

                return RedirectToAction("Login");
            }

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login mu)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {
                try
                {
                    using ( db )
                    {
                        var v = db.Logins.Where(a => a.Matricula_Usuario.Equals(mu.Matricula_Usuario) && a.Senha.Equals(mu.Senha)).FirstOrDefault();
                        if (v != null)
                        {
                            Session["usuarioLogadoID"] = v.Id.ToString();
                            Session["Matricula_UsuarioLogado"] = v.Matricula_Usuario.ToString();
                            Session["tipoMatriculaLogado"] = v.tipoMatricula.ToString();
                            if (Session["tipoMatriculaLogado"].ToString() == "Professor")
                            {
                                return RedirectToAction("Professor/Home");
                            }
                            else if (Session["tipoMatriculaLogado"].ToString() == "Cliente")
                            {
                                return RedirectToAction("Cliente/Home");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    ViewBag.Message = ex.Message;
                }
               
            }
            return View(mu);
        }



        // GET: Logins/Details/5
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

        // GET: Logins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Matricula_Usuario,Senha,Tipo_Matricula_id")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login);
        }

        // GET: Logins/Edit/5
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
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Matricula_Usuario,Senha,Tipo_Matricula_id")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // GET: Logins/Delete/5
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

        // POST: Logins/Delete/5
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
