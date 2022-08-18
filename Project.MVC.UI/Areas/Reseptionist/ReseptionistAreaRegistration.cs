using System.Web.Mvc;

namespace Project.MVC.UI.Areas.Reseptionist
{
    public class ReseptionistAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Reseptionist";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Reseptionist_default",
                "Reseptionist/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}