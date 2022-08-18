using Project.BLL.DesignPatterns.GenericRepository.ConcRep;

using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        AppUserRepository _apRep;

        public HomeController()
        {
            _apRep = new AppUserRepository();
        }


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Photos()
        {
            return View();
        }
        

    }
}