using MVC_Complete_App.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
namespace MVC_Complete_App.Controllers
{
	[RoutePrefix("Search")]
    public class SearchController : ApiController
    {
		Categories cats;
		Products prds;

		public SearchController()
		{
			cats = new Categories();
			prds = new Products();
		}
		/// <summary>
		/// Route parameters must match with the 
		/// parameter names. These parameters names must be STRING
		/// </summary>
		/// <param name="catName"></param>
		/// <param name="prdName"></param>
		/// <param name="condition">AND && / OR ||</param>
		/// <returns></returns>
		[Route("products/{catName}/{condition}/{prdName}")]
		public IHttpActionResult Get(string catName, string condition, string prdName)
		{
			List<Product> result = new List<Product>();

			// read CategoryRowId based on catName
			Category cat = (from c in cats
							where c.CategoryName == catName
							select c).First();
			int catRowId = cat.CategoryRowId;

			switch (condition)
			{
				case "AND":
					result = (from p in prds
							  where p.ProductName == prdName && p.CategoryRowId == catRowId
							  select p).ToList();
					break;
				case "OR":
					result = (from p in prds
							  where p.ProductName == prdName || p.CategoryRowId == catRowId
							  select p).ToList();
					break;
			}
			
			return Ok(result);
		}
    }
}
