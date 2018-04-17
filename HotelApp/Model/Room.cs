using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Model
{
    class Room
    {
        public int Room_No { get; set; }
        public int Hotel_No { get; set; }
        public string Types { get; set; }
        public double Price { get; set; }

        public Room(int roomNo, int hotelNo, string types, double price)
        {
            Room_No = roomNo;
            Hotel_No = hotelNo;
            Types = types;
            Price = price;
        }

        public override string ToString()
        {
            return $"{nameof(Room_No)}: {Room_No}, {nameof(Hotel_No)}: {Hotel_No}, {nameof(Types)}: {Types}, {nameof(Price)}: {Price}";
        }
    }
}
