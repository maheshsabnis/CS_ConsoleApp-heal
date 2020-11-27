using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Complete_App.CustomFilters
{
    public class CustomExceptionFilterAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            Exception ex = filterContext.Exception;
            filterContext.Result = new ViewResult();
        }
    }
}