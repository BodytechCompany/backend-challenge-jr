using BT.Areas.Management.Models;
using BT.Areas.Management.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT.Areas.Management.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Cliente/Customer
        // GET: Customer  
        public ActionResult Index()
        {
            ClienteClient CC = new ClienteClient();
            ViewBag.listCustomers = CC.findAll();

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(ClienteViewModel cvm)
        {
            ClienteClient CC = new ClienteClient();
            CC.Create(cvm.cliente);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ClienteClient CC = new ClienteClient();
            CC.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ClienteClient CC = new ClienteClient();
            ClienteViewModel CVM = new ClienteViewModel();
            CVM.cliente = CC.find(id);
            return View("Edit", CVM);
        }
        [HttpPost]
        public ActionResult Edit(ClienteViewModel CVM)
        {
            ClienteClient CC = new ClienteClient();
            CC.Edit(CVM.cliente);
            return RedirectToAction("Index");
        }
    }
}
