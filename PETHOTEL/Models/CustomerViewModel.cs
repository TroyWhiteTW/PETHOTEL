using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PETHOTEL.entity;

namespace PETHOTEL.Models
{
    public class CustomerViewModel
    {
        public int c_id { get; set; }
        public string c_account { get; set; }
        public string c_password { get; set; }
        public string c_name { get; set; }
        public string c_address { get; set; }
        public string c_phone { get; set; }
        public string c_gmail { get; set; }
        public Nullable<System.Guid> c_valid_guid { get; set; }
        public Nullable<int> c_status { get; set; }

        public List<CustomerViewModel> getlist()
        {
            Entities en = new Entities();
            List<CustomerViewModel> VM_list = new List<CustomerViewModel>();


            var dblist = en.Customer;

            foreach (var item in dblist)
            {
                CustomerViewModel vmitme = new CustomerViewModel();
                vmitme.c_id = item.c_id;
                vmitme.c_name = item.c_name;
                vmitme.c_gmail = item.c_gmail;
                vmitme.c_address = item.c_address;
                vmitme.c_account = item.c_account;
                vmitme.c_phone = item.c_phone;

                VM_list.Add(vmitme);

            }


            return VM_list;



        }


        public void create()
        {

            Entities en = new Entities();

            entity.Customer cs = new entity.Customer();
            cs.c_name = this.c_name;
            cs.c_account = this.c_account;
            cs.c_password = this.c_password;
            cs.c_address = this.c_address;
            cs.c_gmail = this.c_gmail;
            cs.c_phone = this.c_phone;
            en.Customer.Add(cs);
            en.SaveChanges();


        }




        public void Login()
        {
            string message = "";
            using (Entities db = new Entities())
            {
                Customer cs = new entity.Customer();
                var v = db.Customer.Where(a => a.c_account == cs.c_account);
                if (v != null)
                {
                    }

                  


                    else
                    {
                        message = "Invalid credential provided";
                    }
                
                
            }
            
        }

    }

}