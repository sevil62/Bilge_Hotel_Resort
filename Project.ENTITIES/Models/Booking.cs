using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Booking:BaseEntity
    {
        public DateTime BookingDate { get; set; }//Rezervasyon oluşturma tarihi
        public DateTime CheckinDate { get; set; }//Giriş Tarihi
        public DateTime ReleaseDate { get; set; }//Çıkış Tarihi
        public BookingStatus BookingStatus { get; set; }
        public int? AppUserId { get; set; }
        public int? GuestId { get; set; }
        public int? RoomId { get; set; }
        public int? StaffId { get; set; }
        // public int? HotelId { get; set; }

        //Relation Property
        public virtual Room Room { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Guest Guest { get; set; }
        public virtual Staff Staff { get; set; }
        //public virtual Hotel Hotel { get; set; }



    }
}
