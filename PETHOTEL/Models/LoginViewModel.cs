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





        [Display(Name = "帳號")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        public string c_account { get; set; }

        [Display(Name = "密碼")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string c_password { get; set; }

        public void Login()
        {
            
            Entities db = new Entities();
            LoginViewModel lv = new LoginViewModel();
            
            var v = db.Customer.Where(a => a.c_account == lv.c_account).FirstOrDefault();
                
                   
        }




    }
}