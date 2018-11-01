using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pethotel_manager.Entity;
namespace pethotel_manager.Models
{
    public class OrderIndexViewModel
    {
        public List<OrderViewModel> OrderList { get; set; }
    }

    public class OrderViewModel
    {

        public int o_id { get; set; }
        public int r_id { get; set; }
        public int c_id { get; set; }
        public string o_pet_name { get; set; }
        public int o_pet_type { get; set; }
        public string o_pet_type_string {
            get {
                string s = "123";

                switch (o_pet_type)
                {
                    case 0:
                        s = "小狗";
                        break;
                    case 1:
                        s = "小貓";
                        break;
                    case 2:
                        s = "小雞雞";
                        break;

                }

                return s;
            }
        }

        public Room room {
            get {
                Entities en = new Entities();
                return en.Room.FirstOrDefault(x => x.r_id == r_id);
            }
        }

        public Customer customer {
            get {
                Entities en = new Entities();
                return en.Customer.FirstOrDefault(x => x.c_id == c_id);
            }
        }

        public int o_pet_sex { get; set; }
        public string o_pet_content { get; set; }
        public string o_pet_image { get; set; }
        public decimal o_pet_price { get; set; }
        public int o_status { get; set; }
        public DateTime o_create_datetime { get; set; }
        public DateTime o_start_date { get; set; }
        public DateTime o_end_date { get; set; }




        public void create()
        {

            Entities en = new Entities();

            Order item = new Order();
            item.o_pet_name = this.o_pet_name;
            item.r_id = this.r_id;
            item.c_id = this.c_id;
            item.o_pet_type = this.o_pet_type;
            item.o_pet_sex = this.o_pet_sex;
            item.o_pet_content = this.o_pet_content;
            //item.o_pet_image = this.o_pet_image;
            //item.o_pet_price = this.o_pet_price;
            item.o_status = this.o_status;
            item.o_create_datetime = DateTime.Now;
            item.o_start_date = this.o_start_date;
            item.o_end_date = this.o_end_date;



            en.Order.Add(item);
            en.SaveChanges();


        }





    }
}