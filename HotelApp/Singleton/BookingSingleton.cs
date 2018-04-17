using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelApp.Model;

namespace HotelApp.HotelAppClasses.Singleton
{
    class BookingSingleton
    { 
        private static BookingSingleton _instance;

        public static BookingSingleton Instance
        {
            get { return _instance ?? (_instance = new BookingSingleton()); }
        }

        public ObservableCollection<Booking> BookingCatalog { get; }

        private BookingSingleton()
        {
            BookingCatalog = new ObservableCollection<Booking>();
            BookingCatalog.Clear();
            BookingCatalog.Add(new Booking(1, 4, 5, 202, DateTime.Today, DateTime.Now.AddDays(1)));

            //TODO: Create Load Method
            //LoadEventCatalogAsync();

        }

        public void Add(Booking BookingToAdd)
        {
            BookingCatalog.Add(BookingToAdd);
        }

        public void Remove(Booking BookingToRemove)
        {
            BookingCatalog.Remove(BookingToRemove);
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
