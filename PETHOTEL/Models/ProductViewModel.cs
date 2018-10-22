using PETHOTEL.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PETHOTEL.Models
{
    public class ProductViewModel
    {
        public int p_id { get; set; }
        public Nullable<int> p_type { get; set; }
        public string p_name { get; set; }
        public string p_content { get; set; }
        public Nullable<decimal> p_price { get; set; }
        public Nullable<int> p_count { get; set; }
        public string p_image { get; set; }


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
                

                pro_list.Add(pro);

            }


            return pro_list;



        }






























    }
}