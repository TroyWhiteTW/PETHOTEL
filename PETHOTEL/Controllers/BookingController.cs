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

            bk.create();
            return RedirectToAction("Index");
        }
    }
}