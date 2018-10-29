using PETHOTEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PETHOTEL.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            if (Session["customer"] != null) { 
            RoomViewModel rvm = new RoomViewModel();
            return View(rvm.getlist());
            }
            else
            {
                return RedirectToAction("Login", "Customer");
            }
        }
    }
}