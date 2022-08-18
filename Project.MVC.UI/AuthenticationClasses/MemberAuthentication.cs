using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.UI.AuthenticationClasses
{
    public class MemberAuthentication: FilterAttribute, IAuthorizationFilter

    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.HttpContext.Session["member"] == null)
            {
                filterContext.Result = new RedirectResult("/Booking/index");
            }

        }  
    }
}