using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.UI.VMClasses
{
    public class HotelVM
    {
        public Hotel Hotel { get; set; }
        public List<Hotel>Hotels { get; set; }
    }
}