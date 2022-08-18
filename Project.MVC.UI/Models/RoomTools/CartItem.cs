using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC.UI.Models.RoomTools
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long TC { get; set; }
        public long Phone { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ChekingDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public int RoomId { get; set; }
        public int AppUserId { get; set; }
        public int GuestId { get; set; }
        public int StaffId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public decimal SubTotal
        {
            get
            {
                return Price * Quantity;
            }
        }

       
    }
}