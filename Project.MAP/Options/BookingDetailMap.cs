using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class BookingDetailMap:BaseMap<BookingDetail>
    {
        public BookingDetailMap()
        {
            //Ignore(x => x.ID);//burada Ignore ile Id yi yok say diyoruz
            //HasKey(x => new
            //{
            //    x.BookingId,
            //    x.RoomId
            //});//Burada kompozit key olduğundan iki id'yi de primary key olarak ayarlıyoruz
           
        }
    }
}
