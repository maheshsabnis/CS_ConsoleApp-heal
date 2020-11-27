using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MVC_Complete_App
{
    /// <summary>
    /// The Configuration class that will be used
    /// to create WEB API aka REST API in ASP.NET MVC Application
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
