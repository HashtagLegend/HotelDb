using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Eventmaker.Model
{
    class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Place { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }

        public Event()
        {
            
        }

        public Event(int id, string name, string place, DateTime dateTime, string description)
        {
            Id = id;
            Name = name;
            Place = place;
            DateTime = dateTime;
            Description = description;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Place: {2}, DateTime: {3}, Description: {4}", Id, Name, Place, DateTime, Description);
        }
    }
}
