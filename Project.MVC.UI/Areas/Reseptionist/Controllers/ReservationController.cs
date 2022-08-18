using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.MVC.UI.AuthenticationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.UI.Areas.Reseptionist.Controllers
{
    [AdminAuthentication]
    
   
    public class ReservationController : Controller
    {
        RoomRepository _rRep;
        BookingRepository _bRep;


        public ReservationController()
        {
            _rRep = new RoomRepository();
            _bRep = new BookingRepository();

        }

        // GET: Reseptionist/Reservation
        public ActionResult Index()
        {
            var booking = _bRep.GetActives();
            return View(booking);
        }
    }
}