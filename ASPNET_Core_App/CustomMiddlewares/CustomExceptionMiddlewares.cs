using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASPNET_Core_App.CustomMiddlewares
{

	public class ErrorResponse
	{
		public int ErrorCode { get; set; }
		public string ErrorMessage { get; set; }
	}


	/// <summary>
	/// Class ctor injected with the ReqiestDelegate
	/// </summary>
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate requestDelegate;
		public ExceptionHandlerMiddleware(RequestDelegate mydelegate)
		{
			requestDelegate = mydelegate;
		}

		/// <summary>
		/// Logic for Custom Middleware
		/// Used for Exsception Handling
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				// if no exception occured while processing request then just proceed to
				// next middleware in the HttpContext
				await requestDelegate(context);
			}
			catch (Exception ex)
			{
				// if exception occured then handle it and generate response
				// define a custom Http Response Status Code
				context.Response.StatusCode = 500; // internal server error
				string errorMessage = ex.Message;

				var errorResponse = new ErrorResponse()
				{
					 ErrorCode = context.Response.StatusCode,
					 ErrorMessage = errorMessage
				};

				// serialize the errorResponse in JSON format
				string response = JsonSerializer.Serialize(errorResponse);

				// write the response
				await context.Response.WriteAsync(
					  response
					);
				 
			}
		}
	}


	/// <summary>
	/// This class will contain an extension method to register
	/// the ExceptionHandlerMiddleware class in Request processing for
	/// Exception Handling Custom Middleware Logic
	/// </summary>
	public static class CustomExceptionMiddleware
	{
		public static void UseCustomExceptionMiddleware(this IApplicationBuilder builder)
		{
			builder.UseMiddleware<ExceptionHandlerMiddleware>();
		}
	}

}
