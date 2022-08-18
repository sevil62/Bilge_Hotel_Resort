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
    
    public class StaffCleaningController : Controller
    {
        // GET: Admin/StaffCleaning
        StaffRepository _srep;

        public StaffCleaningController()
        {
            _srep = new StaffRepository();
        }
        // GET: Admin/Staff
        public ActionResult StaffCleaningList(int? id)
        {
            StaffVM svm = id == null ? new StaffVM
            {
                Staffs = _srep.GetActives()
            } : new StaffVM { Staff = _srep.Find(id.Value) };
            return View(svm);
        }

        public ActionResult AddStaffCleaning()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStaffCleaning(Staff staff)
        {
            _srep.Add(staff);
            return RedirectToAction("StaffCleaningList");
        }
        public ActionResult UpdateStaffCleaning(int id)
        {
            StaffVM svm = new StaffVM
            {
                Staff = _srep.Find(id)
            };
            return View(svm);
        }
        [HttpPost]
        public ActionResult UpdateStaffCleaning(Staff staff)
        {
            _srep.Update(staff);
            return RedirectToAction("StaffCleaningList");
        }
        public ActionResult DeleteStaffCleaning(int id)
        {
            _srep.Delete(_srep.Find(id));
            return RedirectToAction("StaffCleaningList");
        }
        public ActionResult DetailStaffCleaning(int? id)
        {
            StaffVM svm = id == null ? new StaffVM
            {
                Staffs = _srep.GetActives()
            } : new StaffVM { Staff = _srep.Find(id.Value) };
            return View(svm);

        }
    }
}
