using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Complete_App.CustomFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {

        private void LogRequests(string requestStatus, RouteData routeData)
        {
            string conteoller = routeData.Values["controller"].ToString();
            string action = routeData.Values["action"].ToString();
            // currently show message in output window
            Debug.WriteLine($"Request status is {requestStatus} in controller {conteoller} " +
                $" In action method {action}");
        }

        /// <summary>
        /// Method shows the status of the request is Action Executing
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogRequests("On Action Executing", filterContext.RouteData);
        }
        /// <summary>
        /// Method shows the status of the request is Action Executed
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogRequests("On Action Executes", filterContext.RouteData);
        }

        /// <summary>
        /// Method shows the status of the request is Result Executing
        /// This is result generation starting
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            LogRequests("On Result Executing", filterContext.RouteData);
        }
        /// <summary>
        /// Method shows the status of the request is Result Executing
        /// The Result is generated
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            LogRequests("On Result Executed", filterContext.RouteData);
        }
    }
}