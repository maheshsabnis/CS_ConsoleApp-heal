using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_App.CustomFilters
{
	/// <summary>
	/// This will be an Exception Filter.
	/// This will redirect to Error Page to show the error message
	/// </summary>
	public class ErrorFilter : IExceptionFilter
	{
		/// <summary>
		/// The Model information posted by the request
		/// </summary>
		private readonly IModelMetadataProvider modelMetadataProvider;

		/// <summary>
		/// Injecting the IModelMetadataProvider in FIlter
		/// This injection will be resolved when thw filter
		/// is registered in the COnfigureServices() method
		/// inside services.AddControllerWithViews() method
		/// </summary>
		/// <param name="modelMetadataProvider"></param>
		public ErrorFilter(IModelMetadataProvider modelMetadataProvider)
		{
			this.modelMetadataProvider = modelMetadataProvider;
		}

		/// <summary>
		/// Handle the exception
		/// </summary>
		/// <param name="context"></param>

		public void OnException(ExceptionContext context)
		{
			// Handle Exception to complete the process
			context.ExceptionHandled = true;
			// read theexception
			string errorMessage = context.Exception.Message;
			// start the process for defining the result

			var viewResult = new ViewResult();
			// Setting the ViewName
			viewResult.ViewName = "Error";
			// creating ViewData to pass data to view
			var viewDataDictionary = new ViewDataDictionary(modelMetadataProvider, context.ModelState);

			viewDataDictionary["ControllerName"] = context.RouteData.Values["controller"].ToString();

			viewDataDictionary["ActionName"] = context.RouteData.Values["action"].ToString();
			viewDataDictionary["ErrorMessage"] = errorMessage;

			viewResult.ViewData = viewDataDictionary;


			context.Result = viewResult;
		}
	}
}
