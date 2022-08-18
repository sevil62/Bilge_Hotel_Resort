using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using Project.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.UI.Controllers
{
    public class RegisterController : Controller
    {
        AppUserRepository _apRep;
        GuestRepository _gRep;
        public RegisterController()
        {
            _apRep = new AppUserRepository();
            _gRep = new GuestRepository();
        }
        // GET: Register
        public ActionResult RegisterNow()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterNow(AppUserVM apvm)
        {
            if (ModelState.IsValid)
            {
                AppUser getAppUser = _apRep.FirstOrDefault(x => x.UserName == apvm.Username );

                if (getAppUser != null)
                {
                    TempData["error"] = "Aynı mail adresine ait başka bir kayıt bulunmaktadır!";
                    return View(apvm);
                }
                AppUser app=new AppUser();
                app.UserName=apvm.Username;
                app.Password=apvm.Password;
                _apRep.Add(app);

                

                return RedirectToAction("index", "login");
            }
            else
            {
                return View(apvm);
            }
        }


        //public ActionResult RegisterOk()
        //{
        //    return View();
        //}
    }
}