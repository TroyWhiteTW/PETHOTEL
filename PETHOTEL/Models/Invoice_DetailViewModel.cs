using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PETHOTEL.entity;


namespace PETHOTEL.Models
{
    public class Invoice_DetailViewModel
    {

        Entities en = new Entities();
        public int id_id { get; set; }

        public int i_id { get; set; }

        public int p_id { get; set; }

        public int r_id { get; set; }

        public Product porduct {
            get {
                Entities en = new Entities();
                Product item = new Product();
                item = en.Product.SingleOrDefault(a => a.p_id == p_id);
                return item;

            }
        }
        public Room room {
            get {
                Entities en = new Entities();
                Room item = new Room();
                item = en.Room.SingleOrDefault(a => a.r_id == r_id);
                return item;

            }
        }




        public Invoice_DetailViewModel getone(int id) {
           
            var item =  en.Invoice_Detail.SingleOrDefault(a => a.id_id == id);

            id_id = item.id_id;
            i_id = item.i_id;
            p_id = item.p_id;
            r_id = item.r_id;
            
            return this;
        }


    }
}