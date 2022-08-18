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
    
    public class StaffElectricianController : Controller
    {
        // GET: HumanResources/StaffElectrician
       
            StaffRepository _srep;
            public StaffElectricianController()
            {
                _srep = new StaffRepository();
            }
            
            public ActionResult StaffListElectrician(int? id)
            {
                StaffVM svm = id == null ? new StaffVM
                {
                    Staffs = _srep.GetActives()
                } : new StaffVM { Staff = _srep.Find(id.Value) };
                return View(svm);
            }

            public ActionResult AddStaffElectrician()
            {
                return View();
            }
            [HttpPost]
            public ActionResult AddStaffWaiter(Staff staff)
            {
                _srep.Add(staff);
                return RedirectToAction("StaffListElectrician");
            }
            public ActionResult UpdateStaffElectrician(int id)
            {
                StaffVM svm = new StaffVM
                {
                    Staff = _srep.Find(id)
                };
                return View(svm);
            }
            [HttpPost]
            public ActionResult UpdateStaffElectrician(Staff staff)
            {
                _srep.Update(staff);
                return RedirectToAction("StaffListElectrician");
            }
            public ActionResult DeleteStaffElectrician(int id)
            {
                _srep.Delete(_srep.Find(id));
                return RedirectToAction("StaffListElectrician");
            }
            public ActionResult DetailStaffElectrician(int? id)
            {
                StaffVM svm = id == null ? new StaffVM
                {
                    Staffs = _srep.GetActives()
                } : new StaffVM { Staff = _srep.Find(id.Value) };
                return View(svm);

            }
        
    }
}
