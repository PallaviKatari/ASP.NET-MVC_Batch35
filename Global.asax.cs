using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_Batch35
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Adding Handle Error attribute Globally
            //GlobalFilters.Filters.Add(new HandleErrorAttribute());
        }
    }
    //public class MyExceptionHandler : HandleErrorAttribute
    //{
    //    public override void OnException(ExceptionContext filterContext)
    //    {
    //        Exception e = filterContext.Exception;
    //        filterContext.ExceptionHandled = true;
    //        filterContext.Result = new ViewResult()
    //        {
    //            ViewName = "Error2"
    //        };
    //    }
    //}
}
