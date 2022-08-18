using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Staff:BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long TC { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public double Hour { get; set; }
        public string Password { get; set; }
        
        private double _wage;
        public double Wage {
            
            get
            {
               return _wage = Hour * 26.4423;

            } 
        }
        public Department Department { get; set; }

        //Relation Property
        public virtual  List<Booking>Bookings { get; set; }

    }
}
