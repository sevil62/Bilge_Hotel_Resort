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
    

    public class StaffWaiterController : Controller
    {
        StaffRepository _srep;
        public StaffWaiterController()
        {
            _srep = new StaffRepository();
        }
        // GET: Admin/Staff
        public ActionResult StaffListWaiter(int? id)
        {
            StaffVM svm = id == null ? new StaffVM
            {
                Staffs = _srep.GetActives()
            } : new StaffVM { Staff = _srep.Find(id.Value) };
            return View(svm);
        }

        public ActionResult AddStaffWaiter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStaffWaiter(Staff staff)
        {
            _srep.Add(staff);
            return RedirectToAction("StaffListWaiter");
        }
        public ActionResult UpdateStaffWaiter(int id)
        {
            StaffVM svm = new StaffVM
            {
                Staff = _srep.Find(id)
            };
            return View(svm);
        }
        [HttpPost]
        public ActionResult UpdateStaffWaiter(Staff staff)
        {
            _srep.Update(staff);
            return RedirectToAction("StaffListWaiter");
        }
        public ActionResult DeleteStaffWaiter(int id)
        {
            _srep.Delete(_srep.Find(id));
            return RedirectToAction("StaffListWaiter");
        }
        public ActionResult DetailStaffWaiter(int? id)
        {
            StaffVM svm = id == null ? new StaffVM
            {
                Staffs = _srep.GetActives()
            } : new StaffVM { Staff = _srep.Find(id.Value) };
            return View(svm);

        }
    }
}

