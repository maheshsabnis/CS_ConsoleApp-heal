using System.Web;
using System.Web.Mvc;
using MVC_Complete_App.CustomFilters;
namespace MVC_Complete_App
{
    public class FilterConfig
    {
        /// <summary>
        /// Define filters at application level
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogFilterAttribute());
        }
    }
}
