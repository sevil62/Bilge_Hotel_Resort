
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC.UI.Models.RoomTools
{
    public class BookingVM
    {
       
        public Room Room { get; set; }
        public Booking Booking { get; set; }
        public List<Room>Rooms { get; set; }
        public List<Booking>Bookings { get; set; }

    }
}