using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pethotel_manager.Entity;
using System.Web.Mvc;
namespace pethotel_manager.Models
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


        public void create()
        {

        
            Entities db = new Entity.Entities();
            Product p = new Product();
            p.p_name = this.p_name;
            p.p_type = this.p_type;
            p.p_count = this.p_count;
            p.p_price = this.p_price;
            p.p_content = this.p_content;
            p.p_image = this.p_image;
            db.Product.Add(p);
            db.SaveChanges();
            



        }














    }




    

}