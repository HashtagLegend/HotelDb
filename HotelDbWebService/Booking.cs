namespace HotelDbWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int Booking_id { get; set; }

        public int Hotel_No { get; set; }

        public int Guest_No { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_From { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_To { get; set; }

        public int Room_No { get; set; }

        public virtual Room Room { get; set; }

        public virtual Guest Guest { get; set; }

        public override string ToString()
        {
            return $"{nameof(Booking_id)}: {Booking_id}, {nameof(Hotel_No)}: {Hotel_No}, {nameof(Guest_No)}: {Guest_No}, {nameof(Date_From)}: {Date_From}, {nameof(Date_To)}: {Date_To}, {nameof(Room_No)}: {Room_No}, {nameof(Room)}: {Room}, {nameof(Guest)}: {Guest}";
        }
    }
}
