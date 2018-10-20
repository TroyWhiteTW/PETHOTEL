using pethotel_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pethotel_manager.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NewsViewModel VM)
        {
            
            VM.create();

            return View();
        }
        //public ActionResult Create()
        //{
        //    return View();
        //}


    }
}