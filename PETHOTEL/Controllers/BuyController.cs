using PETHOTEL.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PETHOTEL.Controllers
{
    public class BuyController : Controller
    {
        // GET: Buy
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PETHOTEL.Models.BuyViewModel postback)
        {
            if (this.ModelState.IsValid)
            {   //取得目前購物車
                var currentcart = Models.Cart.Operation.GetCurrentCart();

                //取得目前登入使用者Id
                var userId = HttpContext.User.Identity.Name;

                using (Entities db = new Entities())
                {
                    //建立Order物件
                    var order = new Order()
                    {
                        
                        o_pet_name = postback.RecieverName,
                        o_pet_content = postback.RecieverPhone,
                        o_pet_image = postback.RecieverAddress
                    };
                    //加其入Orders資料表後，儲存變更
                    db.Order.Add(order);
                    db.SaveChanges();

                    //取得購物車中OrderDetai物件
                    var orderDetails = currentcart.ToOrderDetailList(order.o_id);

                    //將其加入OrderDetails資料表後，儲存變更
                    db.Order.AddRange(orderDetails);
                    db.SaveChanges();
                }
                return View("Thanks");
            }
            return View();
            
        }
    }
}