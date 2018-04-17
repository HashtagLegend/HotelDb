using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.HotelAppClasses.Singleton;
using HotelApp.Model;
using HotelApp.ViewModel;

namespace HotelApp.Singleton
{
    class HotelSingleton
    {
        private static HotelSingleton _instance;

        public static HotelSingleton Instance
        {
            get { return _instance ?? (_instance = new HotelSingleton()); }
        }

        public ObservableCollection<Hotel> HotelCatalog { get; }

        private HotelSingleton()
        {
            HotelCatalog = new ObservableCollection<Hotel>();
            HotelCatalog.Clear();
            Add(new Hotel(2, "Vestre Statsfængsel", "Hovedgaden 23, 4300 Roskilde"));

            //TODO: Create Load Method
            //LoadEventCatalogAsync();

        }

        public void Add(Hotel hotel)
        {
            HotelCatalog.Add(hotel);
        }

        public void Remove(Hotel hotelToRemove)
        {
            HotelCatalog.Remove(hotelToRemove);
        }
        //TODO: Create Persistency Services
        //public async void LoadEventCatalogAsync()
        //{
        //    var eventCatalog = await PersistencyServices.LoadEventsFromJsonAsync();
        //    EventCatalog.Clear();

        //    if (eventCatalog != null)
        //        foreach (var eventObject in eventCatalog)
        //        {
        //            EventCatalog.Add(eventObject);
        //        }
        //    else
        //    {
        //        //EventCatalog.Add(new Event(999,"test","test","test",DateTime.Now));
        //    }
        //}
    }
}
