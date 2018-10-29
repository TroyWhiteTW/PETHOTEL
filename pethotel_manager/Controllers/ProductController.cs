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
    public class ProductController : Controller
    {
        [HttpGet]
        [LogActionFilter]
        public ActionResult Index()
        {
            Entities db = new Entities();

            var query = from o in db.Product select o;
            var dataList = query.ToList();
            ViewBag.p = dataList;
            return View();
        }

        [HttpGet]
        [LogActionFilter]
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
        [LogActionFilter]
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

        [HttpGet]
        [LogActionFilter]
        public ActionResult Edit(int id)
        {
            using (Entities db = new Entities())
            {
                var result = (from s in db.Product where s.p_id == id select s).FirstOrDefault();

                return View(result);
            }
        }

        [HttpPost]
        [LogActionFilter]
        public ActionResult Edit(Product postback)
        {
            using (Entities db = new Entities())
            {
                //取得db product資料
                var query = from o in db.Product
                            where o.p_id == postback.p_id
                            select o;
                var pro = query.FirstOrDefault();

                //更新product資料
                pro.p_id = postback.p_id;
                pro.p_type = postback.p_type;
                pro.p_name = postback.p_name;
                pro.p_content = postback.p_content;
                pro.p_price = postback.p_price;
                pro.p_count = postback.p_count;

                //圖片上傳
                HttpPostedFileBase file = Request.Files["productImg"];
                if (file != null && file.ContentLength > 0) //有新圖片
                {
                    //設定上傳路徑               
                    string fileName = Path.GetFileName(file.FileName);
                    string folder = Server.MapPath("~/FileUploads");
                    string path = Path.Combine(folder, fileName);

                    //上傳檔案
                    bool exists = System.IO.Directory.Exists(folder);
                    if (!exists)
                        System.IO.Directory.CreateDirectory(folder);
                    file.SaveAs(path);

                    pro.p_image = fileName;
                }
                //pro.p_image = postback.p_image;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [LogActionFilter]        
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
