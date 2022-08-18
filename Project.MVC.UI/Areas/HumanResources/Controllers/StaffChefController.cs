

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
    
    public class StaffChefController : Controller
    {
        // GET: Admin/StaffChef
        StaffRepository _srep;
        public StaffChefController()
        {
            _srep = new StaffRepository();
        }

        public ActionResult StaffChefList(int? id)
        {
            StaffVM svm = id == null ? new StaffVM
            {
                Staffs = _srep.GetActives()
            } : new StaffVM { Staff = _srep.Find(id.Value) };
            return View(svm);
        }

        public ActionResult AddStaffChef()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStaffChef(Staff staff)
        {
            _srep.Add(staff);
            return RedirectToAction("StaffChefList");
        }
        public ActionResult UpdateStaffChef(int id)
        {
            StaffVM svm = new StaffVM
            {
                Staff = _srep.Find(id)
            };
            return View(svm);
        }
        [HttpPost]
        public ActionResult UpdateStaffChef(Staff staff)
        {
            _srep.Update(staff);
            return RedirectToAction("StaffChefList");
        }
        public ActionResult DeleteStafChef(int id)
        {
            _srep.Delete(_srep.Find(id));
            return RedirectToAction("StaffChefList");
        }
        public ActionResult DetailStaffChef(int? id)
        {
            StaffVM svm = id == null ? new StaffVM
            {
                Staffs = _srep.GetActives()
            } : new StaffVM { Staff = _srep.Find(id.Value) };
            return View(svm);

        }
    }
}