using PETHOTEL.entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace PETHOTEL.Models
{
    public class RoomViewModel
    {
        public int r_id { get; set; }
        public string r_name { get; set; }
        public string r_content { get; set; }
        public Nullable<decimal> r_price { get; set; }
        public Nullable<double> r_temperature { get; set; }
        public Nullable<double> r_wet { get; set; }
        public string r_image { get; set; }
        public string r_image_href { get; set; }


        public List<RoomViewModel> getlist()
        {
            Entities en = new Entities();
            List<RoomViewModel> ro_list = new List<RoomViewModel>();

            var dblist = en.Room;

            foreach (var item in dblist)
            {
                RoomViewModel ro = new RoomViewModel();
                ro.r_image = ro.r_image;
                ro.r_name = ro.r_name;
                ro.r_price = ro.r_price;
                ro.r_content = ro.r_content;
                ro.r_temperature = ro.r_temperature;
                ro.r_wet = ro.r_wet;
                ro.r_image_href = Path.Combine(ConfigurationManager.AppSettings["IMG_FOLDER_PATH"].ToString(), item.r_image);

                ro_list.Add(ro);
            }
            return ro_list;
        }
    }
}