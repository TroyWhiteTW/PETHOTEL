using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PETHOTEL.entity;

namespace PETHOTEL.Models
{
    public class LoginViewModel
    {
        public int c_id { get; set; }

 
        public string c_name { get; set; }
        public string c_address { get; set; }
        public string c_phone { get; set; }
        public string c_gmail { get; set; }




        [Display(Name = "帳號")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        public string c_account { get; set; }

        [Display(Name = "密碼")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string c_password { get; set; }

        public Customer cus {
            get {
                Entities en = new Entities();
                Customer item = new Customer();
                item = en.Customer.SingleOrDefault(a => a.c_id == c_id);
                return item;

            }
        }




    }
}