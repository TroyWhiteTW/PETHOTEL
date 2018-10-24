using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pethotel_manager.Models;
using pethotel_manager.Entity;

namespace pethotel_manager.Controllers
{
    public class OrderController : Controller
    {
        Entities db = new Entities();
        // GET: Order
        public ActionResult Index()
        {

            if (Session["managerid"] != null)     //防跨頁 如果session 不等於null 
            {
                Entities db = new Entities();

                var query = from o in db.Order select o;
                var dataList = query.ToList();
                ViewBag.p = dataList;
                return View();
            }
            else                      //如果強行進入則導到Login頁
            {
                return RedirectToAction("Login", "Manager");
            }




        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(OrderViewModel VM)
        {

            VM.create();

            return View();
        }





        public ActionResult Edit(int id)
        {
            using (Entities db = new Entities())
            {
                var result = (from s in db.Order where s.o_id == id select s).FirstOrDefault();


                return View(result);
            }
        }

        [HttpPost]
        public ActionResult Edit(Models.OrderViewModel postback)
        {
            var query = from o in db.Order
                        where o.o_id == postback.o_id
                        select o;

            var ord = query.FirstOrDefault();
            ord.o_id = postback.o_id;
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