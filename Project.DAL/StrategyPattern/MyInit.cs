using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.DataSets;
using Project.COMMON.Tools;
using Project.DAL.Context;
using Project.ENTITIES.Models;

namespace Project.DAL.StrategyPattern
{


    //Migation yapmıyoruz migration test için yapılır migration da sadece tabloları ve ilişkileri yapabiliyoru veri girişi yapılamaz.Bu nedenle StrategyPattern kurulur Bogus kütüphanesini kullanacağız hazır Data sunuyor bize.
    public class MyInit : CreateDatabaseIfNotExists<MyContext>//Eğer Database yoksa çalışacak bir strajedir.

    {
        //Database'e tam oluşurken veri ekleyebilmek için Seed metodunu ovveride etmeliyiz.
        protected override void Seed(MyContext context)
        {
            #region Admin
            AppUser au = new AppUser();
            au.UserName = "Sevil";
            au.Password = "12345";
            au.Email = "sevar2362@gmail.com";
            au.Role = ENTITIES.Enums.AppUserRole.Admin;
            context.AppUsers.Add(au);
            context.SaveChanges();

            #endregion
            
            #region Satış Müdürü
            AppUser au3 = new AppUser();
            Staff staff2 = new Staff();
            au3.UserName = "Levent";
            au3.Password = "12345";
            au3.Email = "levent@gmail.com";
            au3.Role = ENTITIES.Enums.AppUserRole.Manager;
            au3.ID = 1;
            staff2.ID = au3.ID;
            staff2.UserName = au3.UserName;
            staff2.Password = au3.Password;
            staff2.Email = au3.Email;
            staff2.FirstName = au3.UserName;
            staff2.LastName = "Sişarpsoy";
            staff2.TC = 53985241526;
            staff2.Address = new Address("tr").StreetAddress();
            staff2.City = "İstanbul";
            staff2.Country = "Turkey";
            staff2.Hour = 208;
            staff2.Phone = 5352587415;
            staff2.Department = ENTITIES.Enums.Department.SalesMaanger;
            context.AppUsers.Add(au3);
            context.Staffs.Add(staff2);
            context.SaveChanges();
            #endregion

            #region İnsan kaynakları müdürü
            AppUser au2 = new AppUser();
            Staff staff1 = new Staff();
            au2.ID = 2;
            au2.UserName = "SelahattinA";
            au2.Password = "12345";
            au2.Email = "selahattin@gmail.com";
            au2.Role = ENTITIES.Enums.AppUserRole.Manager;
            staff1.ID = au2.ID;
            staff1.UserName = au2.UserName;
            staff1.Password = au2.Password;
            staff1.Email = au2.Email;
            staff1.FirstName = au2.UserName;
            staff1.LastName = "Alkomut";
            staff1.TC =54786932152;
            staff1.Address = new Address("tr").StreetAddress();
            staff1.City = "İstanbul";
            staff1.Country = "Turkey";
            staff1.Hour = 208;
            staff1.Phone = 5321524525;
            staff1.Department = ENTITIES.Enums.Department.HumanResourcesManager;
            context.AppUsers.Add(au2);
            context.Staffs.Add(staff1);
            context.SaveChanges();
            #endregion

            #region Resepsiyonist Şefi
            AppUser au1 = new AppUser();
            Staff staff = new Staff();
            au1.ID = 3;
            au1.UserName = "Gülay";
            au1.Password = "12345";
            au1.Email = "gülay@gmail.com";
            au1.Role = ENTITIES.Enums.AppUserRole.Reseptionist;
            staff.ID = au1.ID;
            staff.UserName = au1.UserName;
            staff.Password = au1.Password;
            staff.Email= au1.Email;
            staff.FirstName = au1.UserName;
            staff.LastName = "Aydınlık";
            staff.TC = 14536254789;
            staff.Address = new Address("tr").StreetAddress();
            staff.City = "İstanbul";
            staff.Country = "Turkey";
            staff.Hour = 208;
            staff.Phone = 5372541875;
            staff.Department = ENTITIES.Enums.Department.ReseptionistChef;
            context.AppUsers.Add(au1);
            context.Staffs.Add(staff);
            context.SaveChanges();
            #endregion

            #region IT

            Staff s6 = new Staff();
            AppUser user = new AppUser();
            user.ID = 4;
            user.UserName = "Selahattin";
            user.Password = "12345";
            user.Email = "selahattin@gmail.com";
            user.Role = ENTITIES.Enums.AppUserRole.Manager;
            s6.ID = user.ID;
            s6.FirstName = user.UserName;
            s6.UserName = user.UserName;
            s6.LastName = "Karadibag";
            s6.Password = user.Password;
            s6.TC = 12547896325;
            s6.Email = user.Email;
            s6.Address = new Address("tr").StreetAddress();
            s6.City = "İstanbul";
            s6.Country = "Turkey";
            s6.Hour = 208;
            s6.Phone = 5362547852;
            s6.Department = ENTITIES.Enums.Department.ITofficer;
            context.Staffs.Add(s6);
            context.AppUsers.Add(user);
            context.SaveChanges();
            #endregion


            //Reseptionist Ekleme

            for (int i = 1; i < 8; i++)
            {
                Staff s1 = new Staff();
                AppUser au4 = new AppUser();
                au4.UserName = new Name("tr").FirstName();
                au4.Password = "1234";
                au4.ID = i;
                au4.Role = ENTITIES.Enums.AppUserRole.Reseptionist;
                au4.Email= new Internet("tr").Email();
                s1.ID = au4.ID;
                s1.UserName = au4.UserName;
                s1.FirstName = new Name("tr").FirstName();
                s1.LastName = new Name("tr").LastName();
                s1.TC = 28108547582;
                s1.Email = au4.Email;
                s1.Address=new Address("tr").StreetAddress();
                s1.City = "İstanbul";
                s1.Country = "Turkey";
                s1.Hour = 208;
                s1.Phone = 5366254748;
                s1.Password = au4.Password;
                
                s1.Department =ENTITIES.Enums.Department.Reseptionist;
                context.Staffs.Add(s1);
                context.AppUsers.Add(au4);
            }
            context.SaveChanges();


            //Müşteri Ekliyoruz
            for (int i = 1; i < 12; i++)
            {
                Guest gMember = new Guest();
                gMember.ID = i;
                gMember.FirstName = new Name("tr").FirstName();
                gMember.LastName = new Name("tr").LastName();
                gMember.Email = new Internet("tr").Email();
                gMember.TCKimlikNo = 12345678912;
                gMember.Phone = 05373921385;
                context.Guests.Add(gMember);
            }
            context.SaveChanges();


            //Chef Ekleme
            for (int i = 1; i < 12; i++)
            {
                Staff s2 = new Staff();

                s2.ID = i;
                s2.FirstName = new Name("tr").FirstName();
                s2.UserName = new Name("tr").FirstName();
                s2.LastName = new Name("tr").LastName();
                s2.TC = 56425874123;
                s2.Email = new Internet("tr").Email();
                s2.Address = new Address("tr").StreetAddress();
                s2.City = "İstanbul";
                s2.Country = "Turkey";
                s2.Hour = 208;
                s2.Phone = 5366254747;

                s2.Department = ENTITIES.Enums.Department.Chef;
                context.Staffs.Add(s2);
            }
            context.SaveChanges();

            //CleaningStaff Ekleme
            for (int i = 1; i < 12; i++)
            {
                Staff s3 = new Staff();

                s3.ID = i;
                s3.FirstName = new Name("tr").FirstName();
                s3.UserName = new Name("tr").FirstName();
                s3.LastName = new Name("tr").LastName();
                s3.TC = 365478895412;
                s3.Email = new Internet("tr").Email();
                s3.Address = new Address("tr").StreetAddress();
                s3.City = "İstanbul";
                s3.Country = "Turkey";
                s3.Hour = 208;
                s3.Phone = 5451236547;

                s3.Department = ENTITIES.Enums.Department.CleaningStaff;
                context.Staffs.Add(s3);
            }
            context.SaveChanges();

            //Waiter Ekleme
            for (int i = 1; i < 14; i++)
            {
                Staff s4 = new Staff();

                s4.ID = i;
                s4.FirstName = new Name("tr").FirstName();
                s4.UserName = new Name("tr").FirstName();
                s4.LastName = new Name("tr").LastName();
                s4.TC = 45874125639;
                s4.Email = new Internet("tr").Email();
                s4.Address = new Address("tr").StreetAddress();
                s4.City = "İstanbul";
                s4.Country = "Turkey";
                s4.Hour = 208;
                s4.Phone = 5397252426;

                s4.Department = ENTITIES.Enums.Department.Waiter;
                context.Staffs.Add(s4);
            }
            context.SaveChanges();


            //Electrician Ekleme

            Staff s5 = new Staff();

            s5.ID = 1;
            s5.FirstName = new Name("tr").FirstName();
            s5.UserName = new Name("tr").FirstName();
            s5.LastName = new Name("tr").LastName();
            s5.TC = 87452136547;
            s5.Email = new Internet("tr").Email();
            s5.Address = new Address("tr").StreetAddress();
            s5.City = "İstanbul";
            s5.Country = "Turkey";
            s5.Hour = 208;
            s5.Phone = 5321654785;

            s5.Department = ENTITIES.Enums.Department.Electrician;
            context.Staffs.Add(s5);
            context.SaveChanges();

           

            //1.Kat 10 Adet Tek kişilik oda
            for (int i = 1; i < 11; i++)
            {
                Room r = new Room();
                r.NumberPeople = "Tek kişilik";
                r.RoomNumber =Convert.ToInt32("10"+i);
                r.Price = 500;
               
                r.Description = "Bu odalarda minibar,tv,klima,saç kurutma makinası,kablosuz internet ve tek kişilik 1 adet yatak mevcuttur";
                r.RoomFloor = 1;
                context.Rooms.Add(r);
            }
            context.SaveChanges();

            //1.Kat 10 Adet 3 kişilik oda
            for (int i = 1; i < 11; i++)
            {
                Room r = new Room();
                r.NumberPeople = "Üç kişilik";
                r.RoomNumber = Convert.ToInt32("11" + i);
                r.Price = 1000;
               
                r.Description = "Bu odalarda Balkon, minibar,tv,klima,saç kurutma makinası,kablosuz internet ve tek kişilik 3 adet yatak mevcuttur";
                r.RoomFloor = 1;
                context.Rooms.Add(r);
            }
            context.SaveChanges();

            //2.Kat 10 Adet Tek kişilik oda
            for (int i = 1; i < 11; i++)
            {
                Room r = new Room();
                r.NumberPeople = "Tek kişilik";
                r.RoomNumber = Convert.ToInt32("20" + i);
                r.Price = 500;
               
                r.Description = "Bu odalarda minibar,tv,klima,saç kurutma makinası,kablosuz internet ve tek kişilik 1 adet yatak mevcuttur";
                r.RoomFloor = 2;
                context.Rooms.Add(r);
            }
            context.SaveChanges();

            //2.Kat 10 Adet 2 kişilik oda
            for (int i = 1; i < 11; i++)
            {
                Room r = new Room();
                r.NumberPeople = "İki kişilik";
                r.RoomNumber = Convert.ToInt32("21" + i);
                r.Price = 750;
               
                r.Description = "Bu odalarda Balkon, minibar,tv,klima,saç kurutma makinası,kablosuz internet ve tek kişilik 2 adet yatak mevcuttur";
                r.RoomFloor = 2;
                context.Rooms.Add(r);
            }
            context.SaveChanges();

            //3.Kat 10 Adet 2 kişilik oda
            for (int i = 1; i < 11; i++)
            {
                Room r = new Room();
                r.NumberPeople = "İki kişilik";
                r.RoomNumber = Convert.ToInt32("30" + i);
                r.Price = 900;
                
                r.Description = "Bu odalarda Balkon, minibar,tv,klima,saç kurutma makinası,kablosuz internet ve  1 adet double yatak mevcuttur";
                r.RoomFloor = 3;
                context.Rooms.Add(r);
            }
            context.SaveChanges();

            //3.Kat 10 Adet 3 kişilik oda
            for (int i = 1; i < 11; i++)
            {
                Room r = new Room();
                r.NumberPeople = "Üç kişilik";
                r.RoomNumber = Convert.ToInt32("31" + i);
                r.Price = 1500;
                
                r.Description = "Bu odalarda Balkon, minibar,tv,klima,saç kurutma makinası,kablosuz internet ve tek kişilik 1adet ve double 1 adet yatak mevcuttur";
                r.RoomFloor = 3;
                context.Rooms.Add(r);
            }
            context.SaveChanges();

            //4.Kat 10 Adet Tek kişilik oda
            for (int i = 1; i < 11; i++)
            {
                Room r = new Room();
                r.NumberPeople = "Tek kişilik";
                r.RoomNumber = Convert.ToInt32("40" + i);
                r.Price = 750;
               
                r.Description = "Bu odalarda minibar,tv,klima,saç kurutma makinası,kablosuz internet ve tek kişilik 1 adet double yatak mevcuttur";
                r.RoomFloor = 4;
                context.Rooms.Add(r);
            }
            context.SaveChanges();

            //4.kat 1 adet Kral Dairesi
            Room r1 = new Room();
            r1.NumberPeople = "Kral Dairesi";
            r1.RoomNumber = 411;
            r1.Price = 2500;
           
            r1.Description = "Bu odalarda Balkon,minibar,tv,klima,saç kurutma makinası,kablosuz internet ve iki kişilik 1 adet double yatak mevcuttur";
            r1.RoomFloor = 4;
            context.Rooms.Add(r1);
            context.SaveChanges();
        }
    }
}
