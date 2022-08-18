using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class BookingDetail:BaseEntity
    {
        public int TotalDays { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
