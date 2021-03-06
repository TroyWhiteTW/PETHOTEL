﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pethotel_manager.Models;
using pethotel_manager.Entity;

namespace pethotel_manager.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        Entities db = new Entities();

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(ManagerViewModel MM)
        {
            MM.create();

            return RedirectToAction("Login");
        }

        public ActionResult LP33()
        {
            return RedirectToAction("Registration");
        }

        public ActionResult Login()
        {
            return View(); ;
        }

        [HttpPost]
        public ActionResult Login(pethotel_manager.Models.ManagerViewModel reg)
        {
            Entities en = new Entities();
            Manager ma = new Manager();
            var query = (from o in db.Manager where o.m_account == reg.m_account && o.m_password == reg.m_password select o).Count();
            if(query == 1)
            {
                Session["managerid"] = reg.m_account;
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login");  //登入失敗

        }
        public ActionResult Logout()
        {
            //Session.RemoveAll();
            Session["managerid"] = "";

            return RedirectToAction("Index", "Home");
            //return RedirectToAction("Login", "Account");
        }
    }
}