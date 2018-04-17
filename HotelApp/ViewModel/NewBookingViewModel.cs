using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Handler;
using HotelApp.Model;
using HotelApp.HotelAppClasses.Singleton;
using HotelApp.Model;


namespace HotelApp.ViewModel
{
    class NewBookingViewModel
    {
        public int View_Booking_Id { get; set; }
        public int View_Hotel_No { get; set; }
        public int View_Guest_No { get; set; }
        public int View_Room_No { get; set; }
        public DateTime View_Date_From { get; set; }
        public DateTime View_Date_To { get; set; }

        public BookingSingleton BookingList { get; set; }

        public static Booking SelectedBooking { get; set; }

        public BookingHandler Bookinghandler { get; set; }


        public NewBookingViewModel()
        {
            BookingList = BookingSingleton.Instance;
            Bookinghandler = new BookingHandler(this);
        }
        
    }
}
