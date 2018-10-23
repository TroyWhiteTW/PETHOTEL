using pethotel_manager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace pethotel_manager.Models
{
    public class ProductViewModel
    {
        public int p_id { get; set; }

        public int p_type { get; set; }
        public string p_name { get; set; }
        public string p_content { get; set; }
        public int p_price { get; set; }
        public int p_count { get; set; }
        public string p_image { get; set; }



        public void create()
        {
            Entities en = new Entities();
            Product item = new Product();
            item.p_type = this.p_type;
            item.p_name = this.p_name;
            item.p_content = this.p_content;
            item.p_price = this.p_price;
            item.p_count = this.p_count;
            item.p_image = this.p_image;

            en.Product.Add(item);
            en.SaveChanges();
        }



        public List<ProductViewModel> getlist()
        {
            Entities en = new Entities();
            List<ProductViewModel> pro_list = new List<ProductViewModel>();

            var dblist = en.Product;

            foreach (var item in dblist)
            {
                ProductViewModel pro = new ProductViewModel();
                pro.p_name = item.p_name;
                pro.p_content = item.p_content;
                pro.p_price = item.p_price;
                pro.p_image = item.p_image;
                pro.p_image_href = Path.Combine(ConfigurationManager.AppSettings["IMG_FOLDER_PATH"].ToString(), item.p_image);

                pro_list.Add(pro);
            }
            return pro_list;

        }
    }
}