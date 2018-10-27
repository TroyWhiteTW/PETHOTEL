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
        public decimal? r_price { get; set; }
        public double? r_temperature { get; set; }
        public double? r_wet { get; set; }
        public string r_image { get; set; }

        public RoomViewModel DBToVM(Room room)
        {
            RoomViewModel rvm = new RoomViewModel();

            rvm.r_id = room.r_id;
            rvm.r_name = room.r_name;
            rvm.r_content = room.r_content;
            rvm.r_price = room.r_price;
            rvm.r_temperature = room.r_temperature;
            rvm.r_wet = room.r_wet;
            rvm.r_image = room.r_image;
            return rvm;
        }

        public Room VMToDB(RoomViewModel vm)
        {
            Room roomitem = new Room();
            roomitem.r_id = vm.r_id;
            roomitem.r_name = vm.r_name;
            roomitem.r_content = vm.r_content;
            roomitem.r_price = vm.r_price;
            roomitem.r_temperature = vm.r_temperature;
            roomitem.r_wet = vm.r_wet;
            roomitem.r_image = vm.r_image;

            return roomitem;
        }

        public void create()
        {
            Entities en = new Entities();
            Room roomitem = new Room();
            //roomitem.r_id = this.r_id;
            roomitem.r_name = this.r_name;
            roomitem.r_content = this.r_content;
            roomitem.r_price = this.r_price;
            roomitem.r_temperature = this.r_temperature;
            roomitem.r_wet = this.r_wet;
            roomitem.r_image = this.r_image;

            en.Room.Add(roomitem);
            en.SaveChanges();
        }

        public RoomViewModel GetOne(int id)
        {
            Entities en = new Entities();
            Room room = en.Room.SingleOrDefault(a => a.r_id == id);
            return DBToVM(room);
        }

    }


   
}