﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PETHOTEL.entity;

namespace PETHOTEL.Models
{
    public class BookViewModel
    {

        public int o_id { get; set; }  //訂單編號
        public string o_pet_name { get; set; } //姓名
        public int o_pet_sex { get; set; } //手機
        public string o_pet_image { get; set; }  //地址
        public DateTime o_start_date { get; set; }   //開始日期
        public DateTime o_end_date { get; set; }   //結束日期
        public string o_pet_content { get; set; } //備註





        public void create()
        {
            Entities en = new Entities();
            Order book = new Order();
            book.o_id = this.o_id;
            book.o_pet_name = this.o_pet_name;
            book.o_pet_sex = this.o_pet_sex;
            book.o_pet_image = this.o_pet_image;
            book.o_start_date = this.o_start_date;
            book.o_end_date = this.o_end_date;
            book.o_pet_content = this.o_pet_content;

            en.Order.Add(book);
            en.SaveChanges();
        }
    }
}