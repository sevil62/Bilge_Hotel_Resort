using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using Project.MVC.UI.AuthenticationClasses;
using Project.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Project.MVC.UI.Areas.Admin.Controllers
{
    [AdminAuthentication]
    
    public class RoomController : Controller
    {
        RoomRepository _rRep;
       

        public RoomController()
        {
            _rRep = new RoomRepository();
           
        }


        // GET: Admin/Room
        public ActionResult RoomList(int? id)
        {
            RoomVM rvm = id == null ? new RoomVM
            {
                Rooms = _rRep.GetActives()
            } : new RoomVM { Room = _rRep.Find(id.Value) };
            
            
            return View(rvm);
        }

        public ActionResult AddRoom() 
        {
            
            return View();
        }
        //HttpPostedFileBase tipi bizim Front End tarafından BackEnd'e yolladıgımız dosyaları yakalayabildigimiz bir tiptir...
        [HttpPost]
        public ActionResult AddRoom(Room room,HttpPostedFileBase img)
        {
            var result=_rRep.Any(x => x.ImagePath == x.RoomNumber.ToString());
            if (result)
            {
                room.ImagePath = ImageUploader.UploadImage("~/Pictures/", img);
                _rRep.Add(room);
                return RedirectToAction("RoomList");
            }
          
            return RedirectToAction("RoomList");

        }

        public ActionResult UpdateRoom(int id)
        {
            RoomVM rvm = new RoomVM
            {
                Room = _rRep.Find(id)
            };
            return View(rvm);
        }

        [HttpPost]
        public ActionResult UpdateRoom(Room room, HttpPostedFileBase img)
        {
           
            room.ImagePath = ImageUploader.UploadImage("~/Pictures/", img);
            
            _rRep.Update(room);
            return RedirectToAction("RoomList");
        }

        public ActionResult DeleteRoom(int id)
        {
            _rRep.Delete(_rRep.Find(id));
            return RedirectToAction("RoomList");
        }
        public ActionResult DetailRoom(int? id)
        {
            RoomVM rvm = id == null ? new RoomVM            
            {
                Rooms = _rRep.GetActives()
            } : new RoomVM { Room = _rRep.Find(id.Value) };
            return View(rvm);

        }
    }
}