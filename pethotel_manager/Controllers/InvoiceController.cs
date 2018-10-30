using pethotel_manager.ActionFilter;
using pethotel_manager.Entity;
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

        //[HttpGet]
        //[LogActionFilter]
        public ActionResult Delete(int id)
        {
            using (Entities db = new Entities())
            {
                var result = (from s in db.Invoice where s.i_id == id select s).FirstOrDefault();


                db.Invoice.Remove(result);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}