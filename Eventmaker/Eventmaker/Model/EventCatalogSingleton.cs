using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventmaker.Persistency;

namespace Eventmaker.Model
{
    class EventCatalogSingleton
    {
        private static EventCatalogSingleton _instance = new EventCatalogSingleton();

        public static EventCatalogSingleton Instance
        {
            //get
            //{
            //    if (_instance == null)
            //        _instance = new EventCatalogSingleton();
            //    return _instance;
            //}

            get { return _instance ?? (_instance = new EventCatalogSingleton()); }

        }

        public ObservableCollection<Event> Events { get; set; }

        private EventCatalogSingleton()
        {
            Events = new ObservableCollection<Event>();
            LoadEventsAsync();
        }

     

        public async void LoadEventsAsync()
        {
            var events = await PersistencyService.LoadEventsFromJsonAsync();
            if (events != null)
                foreach (var ev in events)
                {
                    Events.Add(ev);
                }
            else
            {
                //Data til testformål
                Events.Add(new Event(1, "Pitching 2end semester Projects", "Auditorium 202", new DateTime(2014, 12, 24, 9, 0, 0), "De studerende fremlægger deres eksamensprojekt"));
                Events.Add(new Event(2, "Eksamen", "lokale 122", new DateTime(2015, 1, 6, 9, 0, 0), "Eksamen 1. semester"));
            }
        }



        public void Add(Event newEvent)
        {
            Events.Add(newEvent);
            PersistencyService.SaveEventsAsJsonAsync(newEvent);
        }

        public void Add(int id, string name, string place, DateTime dateTime, string description)
        {
            Event eve = new Event(id, name, place, dateTime, description);
            Events.Add(eve);
            PersistencyService.SaveEventsAsJsonAsync(eve);
        }

        public void Remove(Event eventToBeRemoved)
        {
            Events.Remove(eventToBeRemoved);
            //PersistencyService.SaveEventsAsJsonAsync(Events);
            PersistencyService.DeleteEventsAsync(eventToBeRemoved);
        }

    }
}
