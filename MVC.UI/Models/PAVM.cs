
using PagedList;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.UI.Models
{
    public class PAVM
    {
        public Room  Room { get; set; }
        public IPagedList< Room>PagedRooms { get; set; }//Sayfalama işlemleri için tutulan Property
    }
}