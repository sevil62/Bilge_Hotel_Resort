using Project.DAL.StrategyPattern;
using Project.ENTITIES.Models;
using Project.MAP.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    public class MyContext:DbContext
    {
        public MyContext():base("MyConnection")
        {
            Database.SetInitializer(new MyInit());//MyInit görevini burada yapacak
        }
        public DbSet<Guest>Guests  { get; set; }
        public DbSet<Booking>Bookings  { get; set; }
        public DbSet<BookingDetail>BookingDetails  { get; set; }
       
        public DbSet<Room>Rooms  { get; set; }
        public DbSet<Staff>Staffs  { get; set; }
        public DbSet<AppUser>AppUsers  { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GuestMap());
            modelBuilder.Configurations.Add(new BookingMap());
            modelBuilder.Configurations.Add(new StaffMap());
            
            modelBuilder.Configurations.Add(new BookingDetailMap());
            modelBuilder.Configurations.Add(new RoomMap());
            modelBuilder.Configurations.Add(new AppUserMap());
           
            
        }

    }
}
