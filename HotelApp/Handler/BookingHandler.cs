using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Model;

using HotelApp.ViewModel;


namespace HotelApp.Handler
{
    class BookingHandler
    {
        public NewBookingViewModel NBVMHandler{ get; set; }
        

        public BookingHandler(NewBookingViewModel bookingView)
        {
            NBVMHandler = bookingView;
        }
        //ToDO: Add Persistency
        public void CreateBooking()
        {
            NBVMHandler.BookingList.Add(new Booking(NBVMHandler.View_Booking_Id, NBVMHandler.View_Hotel_No, NBVMHandler.View_Room_No, NBVMHandler.View_Guest_No, NBVMHandler.View_Date_From, NBVMHandler.View_Date_To));
            
        }
        //ToDo: Add Persistency
        public void DeleteBooking()
        {
            NBVMHandler.BookingList.Remove(NewBookingViewModel.SelectedBooking);
        }

        public void SetSelectedBooking(Booking booking)
        {
            NewBookingViewModel.SelectedBooking = booking;
            
        }
    }
}
