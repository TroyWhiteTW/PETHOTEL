using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PETHOTEL.entity;
namespace PETHOTEL.Models
{
    public class NewsViewModel
    {
       
        public int n_id { get; set; }
        public string n_title { get; set; }
        public string n_content { get; set; }
        public int? n_type { get; set; }
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



        public DateTime? n_create_time { get; set; }


        public List<NewsViewModel> getlist()
        {
            Entities en = new Entities();
            List<NewsViewModel> VM_list = new List<NewsViewModel>();


            var dblist = en.News;

            foreach (var item in dblist) {
                NewsViewModel vmitme = new NewsViewModel();
                vmitme.n_id = item.n_id;
                vmitme.n_content = item.n_content;
                vmitme.n_create_time = item.n_create_time;
                vmitme.n_title = item.n_title;
                vmitme.n_type = item.n_type;

                VM_list.Add(vmitme);

            }


            return VM_list;



        }

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