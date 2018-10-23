using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pethotel_manager.Entity;

namespace pethotel_manager.Models
{
    public class ManagerViewModel
    {
        public int m_id { get; set; }
        public string m_account { get; set; }
        public string m_password { get; set; }
       


        public void create()
        {
            Entities en = new Entities();
            Manager ma = new Manager();
            ma.m_id = this.m_id;
            ma.m_account = this.m_account;
            ma.m_password = this.m_password;
           
          

            en.Manager.Add(ma);
            en.SaveChanges();
        }
    }
}