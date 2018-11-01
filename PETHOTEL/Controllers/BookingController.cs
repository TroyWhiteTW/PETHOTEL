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
        public ActionResult Index(int id)
        {
            Entities en = new Entities();
            BookViewModel BK = new BookViewModel();
            string account = Session["Customer"].ToString();
            Customer customer = en.Customer.FirstOrDefault(x => x.c_account == account);
            Order or = new Order();

            
            BK.c_id = customer.c_id;
            BK.r_id = id;
            return View(BK);
        }

        [HttpPost]
        public ActionResult Index(BookViewModel bk )
        {

            

            bk.create();

            

            return RedirectToAction("Index");
        }
    }
}