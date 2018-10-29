using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PETHOTEL.Models;
using PETHOTEL.entity;

namespace PETHOTEL.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(BookViewModel bk )
        {
            Entities en = new Entities();

            
            string account = Session["Customer"].ToString();
            Customer customer = en.Customer.FirstOrDefault(x => x.c_account == account);

            Order or = new Order();
            or.c_id = customer.c_id;

            en.SaveChanges();
            bk.create();


            return RedirectToAction("Index");
        }
    }
}