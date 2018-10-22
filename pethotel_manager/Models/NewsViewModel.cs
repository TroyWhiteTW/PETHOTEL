using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pethotel_manager.Entity;
namespace pethotel_manager.Models
{
    public class NewsViewModel
    {
       
        public int n_id { get; set; }
        public string n_title { get; set; }
        public string n_content { get; set; }
        public int n_type { get; set; }
        public string n_type_string { get 
                
                {
                string s = "";

                switch (n_type) {
                    case 0:
                        s = "最新消息";
                        break;
                    case 1:
                        s = "優惠活動";
                        break;

                }

                return s;

            } }



        public DateTime n_create_time { get; set; }


        public void create()
        {

            Entities en = new Entities();
            
            News item = new News();
            item.n_title = this.n_title;
            item.n_type = this.n_type;
            item.n_content = this.n_content;
            item.n_create_time = DateTime.Now;
            en.News.Add(item);
            en.SaveChanges();


        }





    }
}