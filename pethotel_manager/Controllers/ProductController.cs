using pethotel_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pethotel_manager.Entity;
using System.IO;

namespace pethotel_manager.Controllers
{
    public class ProductController : Controller
    {
        Entities db = new Entities();
        // GET: Product
        public ActionResult Index()
        {
            if(Session["managerid"] != null)     //防跨頁 如果session 不等於null 
            {
                Entities db = new Entities();

                var query = from o in db.Product select o;
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
            var selectList = new List<SelectListItem>()
                {
                     new SelectListItem {Text="text-1", Value="value-1" },
                     new SelectListItem {Text="text-2", Value="value-2" },
                     new SelectListItem {Text="text-3", Value="value-3" },
                };

            //預設選擇哪一筆
            selectList.Where(q => q.Value == "value-2").First().Selected = true;

            ViewBag.SelectList = selectList;


            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel VM, HttpPostedFileBase productImg)
        {




            if (productImg != null && productImg.ContentLength > 0)
            {
                //設定上傳路徑               
                string fileName = Path.GetFileName(productImg.FileName);
                string folder = Server.MapPath("~/FileUploads");
                string path = Path.Combine(folder, fileName);

                //上傳檔案
                bool exists = System.IO.Directory.Exists(folder);
                if (!exists)
                    System.IO.Directory.CreateDirectory(folder);
                productImg.SaveAs(path);

                VM.p_image = fileName;
            }



            VM.create();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (Entities db = new Entities())
            {
                var result = (from s in db.Product where s.p_id == id select s).FirstOrDefault();


                return View(result);
            }
        }

        [HttpPost]
        public ActionResult Edit(Models.ProductViewModel postback)
        {
            var query = from o in db.Product
                        where o.p_id == postback.p_id
                        select o;

            var pro = query.FirstOrDefault();
            pro.p_id = postback.p_id;
            pro.p_type = postback.p_type;
            pro.p_name = postback.p_name;
            pro.p_content = postback.p_content;
            pro.p_price = postback.p_price;
            pro.p_count = postback.p_count;
            pro.p_image = postback.p_image;

            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            using (Entities db = new Entities())
            {
                var result = (from s in db.Product where s.p_id == id select s).FirstOrDefault();


                db.Product.Remove(result);

                db.SaveChanges();

                return RedirectToAction("Index");
            }


        }
    }
}
