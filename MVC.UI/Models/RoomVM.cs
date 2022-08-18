using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.UI.Models
{
    public class RoomVM
    {
        public List<Room> Rooms { get; set; }
        public Room Room { get; set; }
    }
}