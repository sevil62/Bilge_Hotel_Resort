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
    

    public class StaffITofficerController : Controller
    {
        // GET: HumanResources/StaffITofficer
       
            StaffRepository _srep;
            public StaffITofficerController()
            {
                _srep = new StaffRepository();
            }
            // GET: Admin/Staff
            public ActionResult StaffListITofficer(int? id)
            {
                StaffVM svm = id == null ? new StaffVM
                {
                    Staffs = _srep.GetActives()
                } : new StaffVM { Staff = _srep.Find(id.Value) };
                return View(svm);
            }

            public ActionResult AddStaffITofficer()
            {
                return View();
            }
            [HttpPost]
            public ActionResult AddStaffITofficer(Staff staff)
            {
                _srep.Add(staff);
                return RedirectToAction("StaffListITofficer");
            }
            public ActionResult UpdateStaffITofficer(int id)
            {
                StaffVM svm = new StaffVM
                {
                    Staff = _srep.Find(id)
                };
                return View(svm);
            }
            [HttpPost]
            public ActionResult UpdateStaffITofficer(Staff staff)
            {
                _srep.Update(staff);
                return RedirectToAction("StaffListITofficer");
            }
            public ActionResult DeleteStaffITofficer(int id)
            {
                _srep.Delete(_srep.Find(id));
                return RedirectToAction("StaffListITofficer");
            }
            public ActionResult DetailStaffITofficer(int? id)
            {
                StaffVM svm = id == null ? new StaffVM
                {
                    Staffs = _srep.GetActives()
                } : new StaffVM { Staff = _srep.Find(id.Value) };
                return View(svm);

            }
        
    }
}