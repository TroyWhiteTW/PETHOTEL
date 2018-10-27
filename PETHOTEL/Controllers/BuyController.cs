using PETHOTEL.entity;
using PETHOTEL.Models.Cart;
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
            using (Entities db = new Entities())
            {
                //取得現在顧客
                string account = Session["Customer"].ToString();
                Customer customer = db.Customer.FirstOrDefault(x => x.c_account == account);

                List<Order> orderList = db.Order.Where(
                    x =>
                    x.c_id == customer.c_id &&          //顧客
                    x.o_status == 1 &&                  //結完帳
                    x.o_start_date < DateTime.Now &&
                    x.o_end_date > DateTime.Now         //符合現在時間
                    ).ToList();

                ViewBag.OrderList = orderList;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Checkout()
        {
            if (this.ModelState.IsValid)
            {
                //取得目前購物車
                var currentcart = Models.Cart.Operation.GetCurrentCart();

                //取得目前登入使用者Id
                //var userId = HttpContext.User.Identity.Name; 

                using (Entities db = new Entities())
                {
                    //取得現在顧客
                    string account = Session["Customer"].ToString();
                    Customer customer = db.Customer.FirstOrDefault(x => x.c_account == account);

                    //選擇結帳方式 1:送貨到府 0:送至房間 null:此顧客無房間
                    string type = Request["type"];
                    int roomId = 0;
                    if (!string.IsNullOrEmpty(type))
                    {
                        int typeNum = Convert.ToInt32(type);
                        if (typeNum == 0)
                        {
                            //取得顧客預設房間
                            roomId = db.Order.FirstOrDefault(x =>
                                x.c_id == customer.c_id &&
                                x.o_status == 1 &&
                                x.o_start_date < DateTime.Now &&
                                x.o_end_date > DateTime.Now).r_id.Value;      
                        }
                    }

                    //新增購物車訂單
                    Invoice invoice = new Invoice();
                    invoice.c_id = customer.c_id;
                    invoice.i_send = (!string.IsNullOrEmpty(type)) ? Convert.ToInt32(type) : 1; //1:送貨到府 0:送至房間
                    invoice.i_status = 0;   //0:未付款 1:已付款
                    db.Invoice.Add(invoice);
                    db.SaveChanges();

                    //新增購物車子表
                    foreach (CartItem item in currentcart.cartItems)
                    {
                        for (int i = 0; i < item.Quantity; i++)
                        {
                            Invoice_Detail invoiceDetail = new Invoice_Detail();
                            invoiceDetail.i_id = invoice.i_id;
                            invoiceDetail.p_id = item.Id;
                            invoiceDetail.r_id = roomId; //指定房間Id
                            db.Invoice_Detail.Add(invoiceDetail);
                        }
                    }
                    db.SaveChanges();

                    //建立Order物件
                    //var order = new Order()
                    //{                        
                    //    o_pet_name = postback.RecieverName,
                    //    o_pet_content = postback.RecieverPhone,
                    //    o_pet_image = postback.RecieverAddress
                    //};
                    ////加其入Orders資料表後，儲存變更
                    //db.Order.Add(order);
                    //db.SaveChanges();

                    //取得購物車中OrderDetai物件
                    //var orderDetails = currentcart.ToOrderDetailList(order.o_id);

                    //將其加入OrderDetails資料表後，儲存變更
                    //db.Order.AddRange(orderDetails);
                    //db.SaveChanges();
                }
                return View("Thanks");
            }
            return RedirectToAction("Index");

        }
    }
}