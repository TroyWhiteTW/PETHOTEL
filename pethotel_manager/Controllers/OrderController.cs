using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pethotel_manager.Models;
using pethotel_manager.Entity;
using pethotel_manager.ActionFilter;

namespace pethotel_manager.Controllers
{
    public class OrderController : Controller
    {
        Entities db = new Entities();
        // GET: Order
        [LogActionFilter]
        public ActionResult Index()
        {
            OrderIndexViewModel vm = new OrderIndexViewModel();
            vm.OrderList = new List<OrderViewModel>();


            if (Session["managerid"] != null)     //防跨頁 如果session 不等於null 
            {
                Entities db = new Entities();

                var query = from o in db.Order select o;
                List<Order> dataList = query.ToList();

                //mapping 
                foreach (Order item in dataList)
                {
                    OrderViewModel ovm = new OrderViewModel();
                    ovm.o_id = item.o_id;
                    ovm.r_id = Convert.ToInt32(item.r_id.Value);
                    ovm.c_id = Convert.ToInt32(item.c_id.Value);
                    ovm.o_pet_name = item.o_pet_name;
                    ovm.o_pet_type = Convert.ToInt32(item.o_pet_type.Value);
                    ovm.o_pet_sex = Convert.ToInt32(item.o_pet_sex.Value);
                    ovm.o_pet_content = item.o_pet_content;
                    ovm.o_pet_image = item.o_pet_image;
                    //ovm.o_pet_price = Convert.ToDecimal(item.o_pet_price.Value);
                    ovm.o_status = Convert.ToInt32(item.o_status.Value);
                    ovm.o_create_datetime = Convert.ToDateTime(item.o_create_datetime.Value);
                    ovm.o_start_date = Convert.ToDateTime(item.o_start_date.Value);
                    ovm.o_end_date = Convert.ToDateTime(item.o_end_date.Value);
                    vm.OrderList.Add(ovm);
                }



                //ViewBag.p = dataList;

                //var query_C = from o in db.Customer select o;
                //var dataList_C = query_C.ToList();
                //ViewBag.c = dataList_C;
                //
                //var query_R = from o in db.Room select o;
                //var dataList_R = query_R.ToList();
                //ViewBag.r = dataList_R;


                return View(vm);
            }
            else                      //如果強行進入則導到Login頁
            {
                return RedirectToAction("Login", "Manager");
            }
        }
        [LogActionFilter]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [LogActionFilter]
        public ActionResult Create(OrderViewModel VM)
        {

            var selectList = new List<SelectListItem>()
                {
                     new SelectListItem {Text="text-1", Value="value-1" },
                     new SelectListItem {Text="text-2", Value="value-2" },
                     new SelectListItem {Text="text-3", Value="value-3" },
                };

            //預設選擇哪一筆
            selectList.Where(q => q.Value == "value-2").First().Selected = true;

            ViewBag.SelectList = selectList;


            VM.create();

            return RedirectToAction("Index");
        }




        [LogActionFilter]
        public ActionResult Edit(int id)
        {
            using (Entities db = new Entities())
            {
                var result = (from s in db.Order where s.o_id == id select s).FirstOrDefault();


                return View(result);
            }
        }

        [HttpPost]
        [LogActionFilter]
        public ActionResult Edit(Models.OrderViewModel postback)
        {
            Entities db = new Entities();
            var query = from o in db.Order
                        where o.o_id == postback.o_id
                        select o;

            var ord = query.FirstOrDefault();
            //var item = db.Customer.SingleOrDefault(a => a.c_id == o_c_id);
            //ord.o_id = postback.o_id;
            ord.o_pet_name = postback.o_pet_name;
            ord.o_pet_type = postback.o_pet_type;
            ord.o_pet_sex = postback.o_pet_sex;
            ord.o_pet_content = postback.o_pet_content;
            ord.o_pet_image = postback.o_pet_image;
            ord.o_pet_price = postback.o_pet_price;
            ord.o_status = postback.o_status;
            ord.o_create_datetime = postback.o_create_datetime;
            ord.o_start_date = postback.o_start_date;
            ord.o_end_date = postback.o_end_date;


            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [LogActionFilter]
        public ActionResult Delete(int id)
        {
            using (Entities db = new Entities())
            {
                var result = (from s in db.Order where s.o_id == id select s).FirstOrDefault();


                db.Order.Remove(result);

                db.SaveChanges();

                return RedirectToAction("Index");
            }


        }







    }
}