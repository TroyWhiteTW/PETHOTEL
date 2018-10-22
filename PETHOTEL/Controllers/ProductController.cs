using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PETHOTEL.Models;

namespace PETHOTEL.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {

            ProductViewModel pvm = new ProductViewModel();
            return View(pvm.getlist());
        }
    }
}