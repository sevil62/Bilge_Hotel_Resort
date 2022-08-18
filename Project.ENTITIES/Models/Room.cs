using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Room:BaseEntity
    {

        public decimal Price { get; set; }
        public string NumberPeople { get; set; }
        public string Description { get; set; }
        public int RoomNumber { get; set; }
        public int RoomFloor { get; set; }
        public double Discount { get; set; }
        public string ImagePath { get; set; }
        


        //Relation Property
       
        public virtual List<Booking> Bookings { get; set; }
       

    }
}
