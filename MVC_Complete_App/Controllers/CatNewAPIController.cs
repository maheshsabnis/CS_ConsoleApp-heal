using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_Complete_App.Models;

namespace MVC_Complete_App.Controllers
{
    public class CatNewAPIController : ApiController
    {
		public CatNewAPIController()
		{

		}
		///// <summary>
		///// The Post method with multiple parameters
		///// Accepted as Query String
		///// https://Server:<port>/api/CatNewAPI?CategoryId=<V>&CategoryName=<V>&SubCategoryName=<V>&BasePrice=<V>
		///// </summary>
		///// <returns></returns>
		//public IHttpActionResult Post(string CategoryId, string CategoryName, string SubCategoryName, int BasePrice)
		//{
		//	// store data in CLR object from Parameters
		//	Category cat = new Category()
		//	{
		//		 CategoryId = CategoryId,
		//		 CategoryName = CategoryName,
		//		 SubCategoryName= SubCategoryName,
		//		 BasePrice = BasePrice
		//	};
		//	return Ok();
		//}


		/// <summary>
		/// The Post method with CLR Object having parameter binding using
		/// FromUri, the cleint request will be 
		/// Accepted as Query String
		/// https://Server:<port>/api/CatNewAPI?CategoryId=<V>&CategoryName=<V>&SubCategoryName=<V>&BasePrice=<V>
		/// [FromUri] --> Read the QueryString and map it with the propertie of CLR object
		/// </summary>
		/// <returns></returns>
		//public IHttpActionResult Post([FromUri]Category category)
		//{

		//	return Ok();
		//}

		///// Passing multiple CLR objects as input parameters to POST method
		///// [FromUri]--> Data will be passed in QueryString and will be mapped with CLR object 
		///// [FromBody] --> Data will be passed in HTTP Request body and mapped with CLR object 
		/////
		//public IHttpActionResult Post([FromUri] Category category, [FromBody]Product product)
		//{

		//	return Ok();
		//}


		 ///Data will be accepted from Http Request Body
		public IHttpActionResult Post(CatProductViewModel viewModel)
		{

			return Ok();
		}
	}
}
