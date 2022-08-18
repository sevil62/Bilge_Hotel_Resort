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
    
    // GET: HumanResources/Manager
    public class ManagerController : Controller
        {

            StaffRepository _srep;

            public ManagerController()
            {
                _srep = new StaffRepository();
            }
            // GET: Admin/Category
            public ActionResult ManagerList(int? id)
            {
                StaffVM svm = id == null ? new StaffVM
                {
                    Staffs = _srep.GetActives()
                } : new StaffVM { Staff = _srep.Find(id.Value) };


                return View(svm);
            }
            public ActionResult AddManager()
            {
                return View();
            }
            [HttpPost]
            public ActionResult AddManager(Staff staff)
            {
                _srep.Add(staff);
                return RedirectToAction("ManagerList");
            }
            public ActionResult UpdateManager(int id)
            {
                StaffVM svm = new StaffVM
                {
                    Staff = _srep.Find(id)
                };
                return View(svm);
            }
            [HttpPost]
            public ActionResult UpdateManager(Staff staff)
            {
                _srep.Update(staff);
                return RedirectToAction("ManagerList");
            }
            public ActionResult DeleteManager(int id)
            {
                _srep.Delete(_srep.Find(id));
                return RedirectToAction("ManagerList");
            }
            public ActionResult DetailManager(int? id)
            {
                StaffVM svm = id == null ? new StaffVM
                {
                    Staffs = _srep.GetActives()
                } : new StaffVM { Staff = _srep.Find(id.Value) };
                return View(svm);

            }
        }
    
}