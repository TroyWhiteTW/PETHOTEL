using pethotel_manager.Entity;
using pethotel_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pethotel_manager.Controllers
{
    public class NewsController : Controller
    {
       // Entities db = new Entities();
        // GET: News
        public ActionResult Index()
        {

    





            if (Session["managerid"] != null)     //防跨頁 如果session 不等於null 
            {
                Entities db = new Entities();

                var query = from o in db.News select o;
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




            List<SelectListItem> mySelectItemList = new List<SelectListItem>();

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "最新消息",
                Value = "0",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "新品上架",
                Value = "1",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "其他",
                Value = "2",
                Selected = false
            });

            ViewBag.Fruit = mySelectItemList;

         

            return View();
        }
        [HttpPost]
        public ActionResult Create(NewsViewModel VM)
        {
            List<SelectListItem> mySelectItemList = new List<SelectListItem>();

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "最新消息",
                Value = "0",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "新品上架",
                Value = "1",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "其他",
                Value = "2",
                Selected = false
            });

            ViewBag.Fruit = mySelectItemList;



            VM.create();

            return View();
        }
   
        public ActionResult Edit(int id)
        {
            using (Entities db = new Entities())
            {
                var result = (from s in db.News where s.n_id == id select s).FirstOrDefault();


                return View(result);
            }
        }

        [HttpPost]
        public ActionResult Edit(Models.NewsViewModel postback)
        {
            Entities db = new Entities();

            var query = from o in db.News
                        where o.n_id == postback.n_id
                        select o;

            var ord = query.FirstOrDefault();
            ord.n_id = postback.n_id;
            ord.n_title = postback.n_title;
            ord.n_content = postback.n_content;
            ord.n_type = postback.n_type;
            ord.n_create_time = postback.n_create_time;



            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            using (Entities db = new Entities())
            {
                var result = (from s in db.News where s.n_id == id select s).FirstOrDefault();


                db.News.Remove(result);

                db.SaveChanges();

                return RedirectToAction("Index");
            }


        }










    }
}