using pethotel_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pethotel_manager.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            InvoiceViewModel VM = new InvoiceViewModel();


            return View(VM.getlist());
        }

      

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(InvoiceViewModel VM)
        {

            VM.create();
            return View();
        }

        public ActionResult Edit(int id)
        {

            InvoiceViewModel VM = new InvoiceViewModel();
            VM.getone(id);
            return View(VM);
        }
    }
}