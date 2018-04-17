using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Eventmaker.Annotations;
using Eventmaker.Common;
using Eventmaker.Handler;
using Eventmaker.Model;

namespace Eventmaker.ViewModel
{
    class EventViewModel : INotifyPropertyChanged
    {
        private int _id;
        private string _name; 
        private string _description;
        private string _place;
        private DateTimeOffset _date;
        private TimeSpan _time;

        public static Event SelectedEvent { get; set; }
  
       
        public Handler.EventHandler EventHandler { get; set; }
       
        
        private ICommand _createEventCommand;
       
        public ICommand CreateEventCommand
        {
            get { if (_createEventCommand==null)
                _createEventCommand=new RelayCommand(EventHandler.CreateEvent);
                return _createEventCommand; }
            set { _createEventCommand = value; }
        }

        private ICommand _selectEventCommand;
        public ICommand SelectEventCommand
        {
            get { return _selectEventCommand ?? (_selectEventCommand = new RelayArgCommand<Event>(ev => EventHandler.SetSelectedEvent(ev))); }
            set { _selectEventCommand = value; }
        }

        private ICommand _deleteEventCommand;
       
        public ICommand DeleteEventCommand
        {
            get {return _deleteEventCommand ?? (_deleteEventCommand = new RelayCommand(EventHandler.DeleteEvent));}
            set { _deleteEventCommand = value; }
        }


        public EventCatalogSingleton EventCatalogSingleton { get; set; }

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged();}
        }

        public string Place
        {
            get { return _place; }
            set { _place = value; OnPropertyChanged(); }
        }

   
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        } 
        
        public DateTimeOffset Date
        {
            get { return _date; }
            set { _date = value; }
        }


        public TimeSpan Time
        {
            get { return _time; }
            set { _time = value; }
        }


        public EventViewModel()
        {
            EventHandler = new Handler.EventHandler(this);
            EventCatalogSingleton = EventCatalogSingleton.Instance;
            DateTime dt = System.DateTime.Now;

            _date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            _time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}
