using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pethotel_manager.Models;
using pethotel_manager.Entity;

namespace pethotel_manager.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Entities db = new Entities();
            //宣告回傳商品列表result
            List<Entity.Product> result = new List<pethotel_manager.Entity.Product>();

            //接收轉導的成功訊息
            ViewBag.ResultMessage = TempData["ResultMessage"];
            var s =  (from o in db.Product select o) .ToList();

            return View(s);
            


            
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