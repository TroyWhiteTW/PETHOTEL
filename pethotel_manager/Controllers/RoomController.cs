using pethotel_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pethotel_manager.Entity;

namespace pethotel_manager.Controllers
{
    public class RoomController : Controller
    {
        Entities db = new Entities();
        // GET: Product
        public ActionResult Index()
        {
            Entities db = new Entities();

            var query = from o in db.Room select o;
            var dataList = query.ToList();
            ViewBag.p = dataList;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoomViewModel RM)
        {
            RM.create();

            return View("Index");



        }
    

        public ActionResult Edit(int id)
        {
            using (Entities db = new Entities())
            {
                var result = (from s in db.Room where s.r_id == id select s).FirstOrDefault();


                return View(result);
            }
        }

        [HttpPost]
        public ActionResult Edit(Models.RoomViewModel postback)
        {
            var query = from o in db.Room
                        where o.r_id == postback.r_id
                        select o;


            var rm = query.FirstOrDefault();
            rm.r_id = postback.r_id;
            rm.r_name = postback.r_name;
            rm.r_content = postback.r_content;
            rm.r_price = postback.r_price;
            rm.r_temperature = postback.r_temperature;
            rm.r_wet= postback.r_wet;
            rm.r_image = postback.r_image;
           
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            using (Entities db = new Entities())
            {
                var result = (from s in db.Room where s.r_id == id select s).FirstOrDefault();


                db.Room.Remove(result);

                db.SaveChanges();

                return RedirectToAction("Index");
            }


        }
    }
}
