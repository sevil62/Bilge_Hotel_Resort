using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.UI.Controllers
{
    public class LoginController : Controller
    {
        AppUserRepository _apRep;

        public LoginController()
        {
            _apRep = new AppUserRepository();
        }

        // GET: Login


        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AppUserVM appUserVM)
        {
            if (ModelState.IsValid)
            {

                AppUser appUser = _apRep.FirstOrDefault(x => x.UserName == appUserVM.Username && x.Password == appUserVM.Password);

                if (appUser.Role == ENTITIES.Enums.AppUserRole.Member)
                {

                    Session["member"] = appUser;
                    return RedirectToAction("index", "Booking");
                }
                else if (appUser.Role == ENTITIES.Enums.AppUserRole.Admin)
                {
                    Session["admin"] = appUser;
                    return RedirectToAction("RoomList", "Room", new { area = "Admin" });
                }
                else if (appUser.Role == ENTITIES.Enums.AppUserRole.Manager)
                {
                    Session["manager"] = appUser;
                    return RedirectToAction("ManagerList", "Manager", new { area = "HumanResources" });
                }
                else if (appUser.Role == ENTITIES.Enums.AppUserRole.Reseptionist)
                {
                    Session["reseptionist"] = appUser;
                    return RedirectToAction("index", "Reservation", new { area = "Reseptionist" });
                }

                else
                {
                    TempData["error"] = "Kullanıcı Bilgileri Hatalı !";
                    return View(appUserVM);
                }
            }
            else
            {
                return View(appUserVM);
            }
        }
    }
}