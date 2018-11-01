using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PETHOTEL.entity;

namespace PETHOTEL.Models
{
    public class BookViewModel
    {
        public int o_id { get; set; }  //訂單編號
        public int r_id { get; set; }
        public int c_id { get; set; }
        public int o_status { get; set; }
        public string o_pet_name { get; set; } //姓名
        public int o_pet_type { get; set; }
        public int o_pet_sex { get; set; } //手機
        public string o_pet_image { get; set; }  //地址
        public DateTime o_create_datetime { get; set; }   //開始
        public DateTime o_start_date { get; set; }   //開始日期
        public DateTime o_end_date { get; set; }   //結束日期
        public string o_pet_content { get; set; } //備註
        public Room roo {
            get {
                Entities en = new Entities();
                Room item = new Room();
                item = en.Room.SingleOrDefault(a => a.r_id == r_id);
                return item;

            }
        }
        public Customer cus {
            get {
                Entities en = new Entities();
                Customer item = new Customer();
                item = en.Customer.SingleOrDefault(a => a.c_id == c_id);
                return item;
            }
        }

        public void create()
        {
            Entities en = new Entities();
            Order book = new Order();
         
            book.o_pet_name = this.o_pet_name;
            book.o_pet_sex = this.o_pet_sex;
            book.o_pet_type = this.o_pet_type;
            book.o_pet_image = this.o_pet_image;
            book.o_status = this.o_status;
            book.o_create_datetime = this.o_create_datetime;
            book.o_start_date = this.o_start_date.Date;
            book.o_end_date = Convert.ToDateTime(this.o_end_date.Date.ToString("yyyy-MM-dd"));
            book.o_pet_content = this.o_pet_content;
            book.c_id = this.c_id;
            book.r_id = this.r_id;

            en.Order.Add(book);
            en.SaveChanges();
        }
    }
}