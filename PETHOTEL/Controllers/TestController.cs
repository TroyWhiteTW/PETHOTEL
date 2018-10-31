using PETHOTEL.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PETHOTEL.Models;

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


        public ActionResult testIOT(int id)
        {
            Entities en = new Entities();
            BookViewModel BK = new BookViewModel();

            //取得顧客資料
            string account = Session["Customer"].ToString();
            Customer customer = en.Customer.FirstOrDefault(x => x.c_account == account);

            //取得顧客最新訂單
            Order or = new Order();
            or = en.Order.OrderBy(x => x.o_create_datetime).FirstOrDefault(x => x.c_id == customer.c_id);
        
            //組成ViewModel
            BK.o_id = or.o_id;
            BK.r_id = id;
            BK.c_id = customer.c_id;
            BK.o_pet_name = or.o_pet_name;
            BK.o_pet_type = (or.o_pet_type!=null)? or.o_pet_type.Value:0;   //int? 取值需用 xx.Value
            BK.o_pet_sex = (or.o_pet_sex != null) ? or.o_pet_sex.Value : 0;
            BK.o_pet_image = or.o_pet_image;
            BK.o_start_date = (or.o_start_date != null) ? or.o_start_date.Value : DateTime.Now;
            BK.o_end_date = (or.o_end_date != null) ? or.o_end_date.Value : DateTime.Now;
            BK.o_pet_content = or.o_pet_content;

            return View(BK);

        }
    }
}