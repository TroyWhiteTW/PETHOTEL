﻿using PETHOTEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PETHOTEL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            NewsViewModel VM = new NewsViewModel();

            

            ViewBag.Message = "Your application description page.";

            return View(VM.getlist());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult home()
        {
            NewsViewModel VM = new NewsViewModel();

            Session["123"] = 456;
            
            ViewBag.Message = "Your application description page.";

            return View(VM.getlist());
        }


        public ActionResult TEST()
        {
            

            return View();
        }

    }

}