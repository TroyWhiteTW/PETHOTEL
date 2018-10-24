using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PETHOTEL.entity;
using PETHOTEL.Models;

namespace PETHOTEL.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CustomerViewModel VM)
        {
            
            VM.create();

            return View();
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel lv)
        {
            Entities db = new Entities();
            var v = db.Customer.Where(a => a.c_account == lv.c_account).FirstOrDefault();
            if (v != null)
            {

                //Session["customer"] = lv.c_account;
                return RedirectToAction("home", "Home");
      
            }
            return View();

        }
        
    }
        
}