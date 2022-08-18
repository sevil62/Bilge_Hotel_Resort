using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC.UI.Models
{
    public class RoomVM
   
    {
        public Room  Room { get; set; }
        public List<Room>Rooms  { get; set; }
       
    }
}