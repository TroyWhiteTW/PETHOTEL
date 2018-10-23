using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using pethotel_manager.Entity;



namespace pethotel_manager.Models
{
    public class RoomViewModel
    {

        public int r_id { get; set; }
        public string r_name { get; set; }
        public string r_content { get; set; }
        public int r_price { get; set; }
        public float r_temperature { get; set; }
        public float r_wet { get; set; }
        public string r_image { get; set; }
        public string r_image_href { get; set; }


        public void create()
        {
            Entities en = new Entities();
            Room roomitem = new Room();
            roomitem.r_id = this.r_id;
            roomitem.r_name = this.r_name;
            roomitem.r_content = this.r_content;
            roomitem.r_price = this.r_price;
            roomitem.r_temperature = this.r_temperature;
            roomitem.r_wet = this.r_wet;
            roomitem.r_image = this.r_image;

            roomitem.r_image_href = Path.Combine(ConfigurationManager.AppSettings["IMG_FOLDER_PATH"].ToString(), roomitem.r_image);


            en.Room.Add(roomitem);
            en.SaveChanges();
        }

    }


   
}