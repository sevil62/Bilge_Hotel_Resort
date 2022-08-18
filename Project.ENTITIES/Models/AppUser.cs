using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AppUser:BaseEntity
    {
        public AppUser()
        {
            Role = AppUserRole.Member;
            //ActivationCode = Guid.NewGuid();
        }
       
        public string UserName { get; set; }
        
        public string Password { get; set; }
        public string Email { get; set; }
        ////Guid sizin unique(benzeri olmayan) bir kod üretmenizi saglayan bir yapıdır...
        //public Guid ActivationCode { get; set; }
        //public bool Active { get; set; }
        public AppUserRole Role { get; set; }

        //Relation Property
        //public virtual  Guest Guest { get; set; }
        public virtual List<Booking>Bookings  { get; set; }
    }
}
