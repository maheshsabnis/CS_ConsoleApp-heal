using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Complete_App
{
    public class RouteConfig
    {
        /// <summary>
        /// Method that will create route template as 
        /// {controller}/{action}/{id}
        /// {controller}, Controller name (without th word controlle e.g. CategoryController)
        /// the {controller} will be Category
        /// {action}, the action name in the controller
        /// {id} this is optional, represents the 'id' parameter for the method
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // added for enabling Custom Attribute Routes on Controller class
            // on action method
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
