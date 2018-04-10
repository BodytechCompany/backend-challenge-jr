using BT.Areas.Cliente.Models;
using BT.Areas.Cliente.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT.Areas.Cliente.Controllers
{
    public class FichaTreinoController : Controller
    {
        // GET: Management/FichaTreino
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["Matricula_UsuarioLogado"]);
            if (id != null)
            {
                FichaTreinoClient CC = new FichaTreinoClient();
                ViewBag.listFichaTreinos = CC.findByMatricula_id(id);
            }
          
            return View();
        }

     
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(FichaTreinoViewModel cvm)
        {
            FichaTreinoClient CC = new FichaTreinoClient();
            CC.Create(cvm.fichaTreino);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            FichaTreinoClient CC = new FichaTreinoClient();
            CC.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            FichaTreinoClient CC = new FichaTreinoClient();
            FichaTreinoViewModel CVM = new FichaTreinoViewModel();
            CVM.fichaTreino = CC.find(id);
            return View("Edit", CVM);
        }
        [HttpPost]
        public ActionResult Edit(FichaTreinoViewModel CVM)
        {
            FichaTreinoClient CC = new FichaTreinoClient();
            CC.Edit(CVM.fichaTreino);
            return RedirectToAction("Index");
        }
    }
}
