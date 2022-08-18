using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Guest:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long TCKimlikNo { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }

        //Relation Property
        public virtual List<Booking>Bookings  { get; set; }
        //public virtual AppUser AppUser { get; set; }
    }
}
