using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.MVC.UI.AuthenticationClasses;
using Project.MVC.UI.Models.RoomTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.UI.Controllers
{
    public class BookingController : Controller
    {
        RoomRepository _rRep;
        AppUserRepository _appUserRepository;
        BookingRepository _bookingRepository;
        BookingDetailRepository _bookingDetailRepository;
        GuestRepository _guestRepository;
       

        public BookingController()
        {
            _rRep = new RoomRepository();
            _appUserRepository = new AppUserRepository();
            _bookingRepository = new BookingRepository();
            _bookingDetailRepository = new BookingDetailRepository();
            _guestRepository = new GuestRepository();
           
        }
       
        // GET: Booking
        public ActionResult Index()
        {
            var rooms = _rRep.GetActives();
            return View(rooms);
        }
        [MemberAuthentication]
        public ActionResult AddToCart(int id)
        {
            Room room = _rRep.Find(id);
            if (room != null)
                return View(room);
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddToCart(CartItem model) // room id ile beraber tarihlerinde gelmesi gerekir
        {
            try
            {
                Room room = _rRep.Find(model.RoomId);

                Cart c = null;
               
                if (Session["scart"] == null)
                {
                    c = new Cart();
                }
                else
                {
                    c = Session["scart"] as Cart;
                }
                CartItem ci = new CartItem();
                ci.ID = room.ID;
                ci.FirstName = model.FirstName;
                ci.LastName = model.LastName;
                ci.TC = model.TC;
                ci.Phone = model.Phone;
                ci.RoomId = model.RoomId;
                ci.Name = room.NumberPeople;
                
               
                ci.BookingDate = DateTime.Now;
                ci.ChekingDate = model.ChekingDate;
                ci.ReleaseDate = model.ReleaseDate;
                ci.BookingStatus = model.BookingStatus;
                ci.Quantity = (int)(model.ReleaseDate - model.ChekingDate).TotalDays; //2. tarihten 1.yi çıkar aradaki farkı gün olarak ver.Tabiki Quantity int olduğu için int'a da cast etmemiz gerekiyor.
                int totalday=(int)(ci.ChekingDate-ci.BookingDate).TotalDays;
                if (totalday>=30 && ci.BookingStatus==ENTITIES.Enums.BookingStatus.allinclusive)
                {
                  ci.Price=0.82m*room.Price;
                }

                else if (totalday >= 30 && ci.BookingStatus == ENTITIES.Enums.BookingStatus.fullpension)
                {
                    ci.Price = 0.84m*room.Price;
                }

                else if (totalday >= 90)
                {
                    ci.Price= room.Price*0.77m;
                     
                }
               
                else
                {
                    ci.Price = room.Price;
                }
                
                AppUser user = Session["admin"] as AppUser;
                if (user != null)
                    ci.AppUserId = user.ID;
                else 
                {
                    user = Session["member"] as AppUser;
                    if (user != null)
                    {
                        ci.AppUserId = user.ID;
                    }
                    user = Session["reseptionist"] as AppUser;
                    if (user != null)
                    {
                        ci.AppUserId = user.ID;
                    }

                    user = Session["manager"] as AppUser;
                    if (user != null)
                    {
                        ci.AppUserId = user.ID;
                    }
                }
                
                
                c.AddItem(ci);
                Session["scart"] = c;

                return RedirectToAction("MyCart");
            }
            catch (System.Exception)
            {
                TempData["error"] = $"{model.RoomId} karşılık gelen bir oda bulunamadı!";
                return View();

            }

        }
        [MemberAuthentication]
        public ActionResult MyCart()
        {
            if (Session["scart"] != null)
            {
                return View();
            }
            else
            {
                TempData["error"] = "Rezervan işleminde oda bulunmamaktadır!";
                return RedirectToAction("Index");
            }

        }
        [MemberAuthentication]
        public ActionResult CompleteCart()
        {
            Cart cart = Session["scart"] as Cart;
            foreach (var item in cart.myCart)
            {
                AppUser user = _appUserRepository.FirstOrDefault(x => x.ID == item.AppUserId);
                Guest guest = new Guest();
                guest.FirstName = item.FirstName;
                guest.LastName = item.LastName;
                guest.TCKimlikNo = item.TC;
                guest.Email = user.Email;
                guest.Phone = item.Phone;
                _guestRepository.Add(guest);
                Room room = _rRep.Find(item.RoomId);
                Booking booking = new Booking();
                booking.AppUserId = item.AppUserId;
                booking.ReleaseDate = item.ReleaseDate;
                booking.BookingDate = item.BookingDate;
                booking.CheckinDate = item.ChekingDate;
                booking.RoomId = room.ID;
                booking.GuestId = guest.ID;
                _bookingRepository.Add(booking);
                
                BookingDetail bookingDetail = new BookingDetail();
                bookingDetail.UnitPrice = item.Price;
                bookingDetail.SubTotal = item.SubTotal;
                bookingDetail.TotalDays = item.Quantity;
                bookingDetail.BookingId = booking.ID;
                _bookingDetailRepository.Add(bookingDetail);
                room.Status = ENTITIES.Enums.DataStatus.Rented;
                _rRep.Update(room);
                ViewBag.OrderNumber = "156565";
                Session.Remove("scart");

            }
            return View();
        }
    }
}