using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Model;
using HotelApp.Singleton;
using HotelApp.Handler;

namespace HotelApp.ViewModel
{
    class HotelVM
    {
        public int Hotel_NoVM { get; set; }
        public string HotelNameVM { get; set; }
        public string HotelAddressVM { get; set; }
        public HotelSingleton HotelList { get; set; }

        public HotelHandler HHandler { get; set; }

        public static Hotel SelectedHotel { get; set; }

        public HotelVM()
        {
            HotelList = HotelSingleton.Instance;
            HHandler = new HotelHandler(this);
        }
        
    }
}
