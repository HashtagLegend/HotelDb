using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Model;
using HotelApp.ViewModel;

namespace HotelApp.Handler
{
    class HotelHandler
    {
        public HotelVM HotelVM { get; set; }

        public HotelHandler(HotelVM hotel)
        {
            HotelVM = hotel;
        }
        //TODO: Add Persistency
        public void CreateHotel()
        {  
            
           HotelVM.HotelList.Add(new Hotel(HotelVM.Hotel_NoVM, HotelVM.HotelNameVM, HotelVM.HotelAddressVM));
        }

        public void DeleteHotel()
        {
            HotelVM.HotelList.Remove(HotelVM.SelectedHotel);
        }


    }
}
