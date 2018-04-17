using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Model
{
    class Booking
    {
        public int Booking_Id { get; set; }
        public int Hotel_No { get; set; }
        public int Guest_No { get; set; }
        public int Room_No { get; set; }
        public DateTime Date_From { get; set; }
        public DateTime Date_To { get; set; }

        public Booking(int bookingId, int hotelNo, int guestNo, int roomNo, DateTime dateFrom, DateTime dateTo)
        {
            Booking_Id = bookingId;
            Hotel_No = hotelNo;
            Guest_No = guestNo;
            Room_No = roomNo;
            Date_From = dateFrom;
            Date_To = dateTo;
        }

        public override string ToString()
        {
            return $"{nameof(Booking_Id)}: {Booking_Id}, {nameof(Hotel_No)}: {Hotel_No}, {nameof(Guest_No)}: {Guest_No}, {nameof(Room_No)}: {Room_No}, {nameof(Date_From)}: {Date_From}, {nameof(Date_To)}: {Date_To}";
        }
    }
}
