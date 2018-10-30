using pethotel_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pethotel_manager.Entity;
using System.IO;
using pethotel_manager.ActionFilter;

namespace pethotel_manager.Controllers
{
    public class RoomController : Controller
    {
        Entities db = new Entities();
        // GET: Product

        [LogActionFilter]
        public ActionResult Index()
        {
            if (Session["managerid"] != null)   //防跨頁 如果session 不等於null 
            {  

                Entities db = new Entities();

            var query = from o in db.Room select o;
            var dataList = query.ToList();
            ViewBag.r = dataList;
            return View();
            }
            else                            //如果強行進入則導到Login頁
            {
                return RedirectToAction("Login", "Manager");
            }
        }
        [LogActionFilter]//對嗎
        public ActionResult Create()
        {
            return View();
        }
        [LogActionFilter]
        [HttpPost]
        public ActionResult Create(RoomViewModel RM , HttpPostedFileBase roomImg)
        {
            if (roomImg != null && roomImg.ContentLength > 0)
            {
                //設定上傳路徑               
                string fileName = Path.GetFileName(roomImg.FileName);
                string folder = Server.MapPath("~/FileUploads");
                string path = Path.Combine(folder, fileName);

                

                //上傳檔案
                bool exists = System.IO.Directory.Exists(folder);
                if (!exists)
                    System.IO.Directory.CreateDirectory(folder);
                roomImg.SaveAs(path);

                RM.r_image = fileName;
            }
            RM.create();
            return RedirectToAction("Index");


        }

        [LogActionFilter]
        public ActionResult Edit(int id)
        {
            using (Entities db = new Entities())
            {
                var result = (from s in db.Room where s.r_id == id select s).FirstOrDefault();


                return View(result);
            }
        }
        [LogActionFilter]
        [HttpPost]
        public ActionResult Edit(Models.RoomViewModel postback, HttpPostedFileBase roomImg)
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


            //if (roomImg != null && roomImg.ContentLength > 0)
            //{
            //    //設定上傳路徑               
            //    string fileName = Path.GetFileName(roomImg.FileName);
            //    string folder = Server.MapPath("~/FileUploads");
            //    string path = Path.Combine(folder, fileName);



            //    //上傳檔案
            //    bool exists = System.IO.Directory.Exists(folder);
            //    if (!exists)
            //        System.IO.Directory.CreateDirectory(folder);
            //    roomImg.SaveAs(path);

            //    postback.r_image = fileName;
            //}

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [LogActionFilter]
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
