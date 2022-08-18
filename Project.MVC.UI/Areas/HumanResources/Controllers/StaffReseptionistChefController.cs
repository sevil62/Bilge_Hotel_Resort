using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.MVC.UI.AuthenticationClasses;
using Project.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.UI.Areas.HumanResources.Controllers
{
    [AdminAuthentication]
    

    public class StaffReseptionistChefController : Controller
    {
        StaffRepository _srep;
        public StaffReseptionistChefController()
        {
            _srep = new StaffRepository();
        }
        // GET: HumanResources/StaffReseptionistChef
        public ActionResult StaffListReseptionist(int? id)
        {
            StaffVM svm = id == null ? new StaffVM
            {
                Staffs = _srep.GetActives()
            } : new StaffVM { Staff = _srep.Find(id.Value) };
            return View(svm);
        }

        public ActionResult AddStaffReseptionist()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStaffReseptionist(Staff staff)
        {
            _srep.Add(staff);
            return RedirectToAction("StaffListReseptionist");
        }
        public ActionResult UpdateStaffReseptionist(int id)
        {
            StaffVM svm = new StaffVM
            {
                Staff = _srep.Find(id)
            };
            return View(svm);
        }
        [HttpPost]
        public ActionResult UpdateStaffReseptionist(Staff staff)
        {
            _srep.Update(staff);
            return RedirectToAction("StaffListReseptionist");
        }
        public ActionResult DeleteStaffReseptionist(int id)
        {
            _srep.Delete(_srep.Find(id));
            return RedirectToAction("StaffListReseptionist");
        }
        public ActionResult DetailStaffReseptionist(int? id)
        {
            StaffVM svm = id == null ? new StaffVM
            {
                Staffs = _srep.GetActives()
            } : new StaffVM { Staff = _srep.Find(id.Value) };
            return View(svm);

        }
    }
}