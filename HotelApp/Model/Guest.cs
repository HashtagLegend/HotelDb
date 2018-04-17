using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Model
{
    class Guest
    {
        public int Guest_No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Guest(int guestNo, string name, string address)
        {
            Guest_No = guestNo;
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Guest_No)}: {Guest_No}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }
}
