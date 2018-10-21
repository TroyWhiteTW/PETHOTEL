using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pethotel_manager.Models;

namespace pethotel_manager.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel vm)
        {
            vm.create();
            TempData["ResultMessage"] = String.Format("商品[{0}]成功建立", vm.p_name);

            //轉導Product/Index頁面
            return RedirectToAction("Create");
        }

    }
}