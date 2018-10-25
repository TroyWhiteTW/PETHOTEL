using PETHOTEL.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PETHOTEL.Controllers
{
    public class TestController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            using (entity.Entities db = new Entities())
            {
                var result = (from s in db.Product select s).ToList();
                return View(result);
            }
            
        }

        //取得目前購物車頁面
        public ActionResult GetCart()
        {
            return PartialView("_CartPartial");
        }

        //以id加入Product至購物車，並回傳購物車頁面
        public ActionResult AddToCart(int id)
        {
            System.Diagnostics.Debug.WriteLine("A" + id);
            var currentCart = Models.Cart.Operation.GetCurrentCart();
            currentCart.AddProducts(id);
            System.Diagnostics.Debug.WriteLine(id);
            return PartialView("_CartPartial");
        }

        //以id移除購物車Product，並回傳購物車頁面
        public ActionResult RemoveFromCart(int id)
        {
            //var currentCart = Models.Cart.Operation.GetCurrentCart();
            //currentCart.RemoveProduct(id);
            var currentCart = Models.Cart.Operation.GetCurrentCart();
            currentCart.RemoveProduct(id);
            return PartialView("_CartPartial");
        }

        //清空購物車，並回傳購物車頁面
        public ActionResult ClearCart()
        {
            var currentCart = Models.Cart.Operation.GetCurrentCart();
            currentCart.ClearCart();
            return PartialView("_CartPartial");
        }


        public ActionResult testIOT()
        {
            return View();
        }
    }
}