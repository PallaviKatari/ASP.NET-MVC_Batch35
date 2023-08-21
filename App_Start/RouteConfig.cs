using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Batch35
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Enabling attribute routing 
            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default", //Route Name
                url: "{controller}/{action}/{id}", //Route Pattern
                defaults: new
                {
                    controller = "Home", //Controller Name
                    action = "Index", //Action method Name
                    id = UrlParameter.Optional //Defaut value for above defined parameter
                }
                //constraints: new { id = @"\d+" } //Restriction for id
            );

            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //     "Default", // Route name
            //     "{controller}/{action}/{id}", // Route Pattern
            //     new { controller = "Student", action = "Index", id = UrlParameter.Optional }, // Default values for parameters
            //     new { controller = "^S.*", action = "^Index$" } ,
            //     constraints: new { id = @"\d+" } //Restriction for controller and action
            //);

        }
    }
}
