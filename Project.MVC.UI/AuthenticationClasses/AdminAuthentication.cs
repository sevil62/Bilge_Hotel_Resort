using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.UI.AuthenticationClasses
{
    public class AdminAuthentication: FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["admin"]==null)
            {
                if (filterContext.HttpContext.Session["manager"] == null)
                {
                    if (filterContext.HttpContext.Session["reseptionist"] == null)
                    {
                        filterContext.Result = new RedirectResult("~/Home/index");
                    }
                }
            }
          
        }
    }
}