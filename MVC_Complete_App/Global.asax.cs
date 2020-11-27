using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_Complete_App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            // Call the UnityConfig to register all depednencies
            UnityConfig.RegisterComponents();

            // call the Configuratuin for WEB APIs
            // GlobalConfiguration, class will register
            // WEB API and its routes  in te current Application
            GlobalConfiguration.Configure(WebApiConfig.Register);


            // register action filters
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            // register the routes to defing URL routing to 
            // send requests for Controllers and its action methods
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // To create a build of JavaScript, CSS so that they can load in
            // browser and execute
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
