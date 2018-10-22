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
            var s = (from o in db.Product select o).ToList();

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

        public ActionResult Edit()
        {
            Entities db = new Entities();

            //抓取Product.Id等於輸入id的資料
            var result = (from s in db.Product select s);
            if (result != default(Entity.Product)) //判斷此id是否有資料
            {
                return View(result); //如果有回傳編輯商品頁面
            }
            else
            {   //如果沒有資料則顯示錯誤訊息並導回Index頁面
                TempData["resultMessage"] = "資料有誤，請重新操作";
                return RedirectToAction("Index");
            }





        }
    }
}