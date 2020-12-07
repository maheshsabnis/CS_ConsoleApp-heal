using ASPNET_Core_App.Models;
using ASPNET_Core_App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_App.Controllers
{
	/// <summary>
	/// Use [action] is you want to add multiple GET  /POST / PUT method in one API
	/// and want to access them with its name 
	/// </summary>
	[Route("api/[controller]/[action]")]
	//[ApiController]
	public class CategoryBinderAPIController : ControllerBase
	{
		private readonly IBizRepository<Categories, int> catRepository;
		public CategoryBinderAPIController(IBizRepository<Categories, int> repository)
		{
			catRepository = repository;
		}


		[HttpPost]
		// ActionNameAttribute will be used to map the method to the name of action in Request URL
		[ActionName("PostBody")] // http://localhost:5001/apoi/CategoryBinderAPI/PostBody
		public async Task<IActionResult> PostFromBody([FromBody]Categories input)
		{
			if (ModelState.IsValid)
			{
				var result = await catRepository.CreateAsync(input);
				return Ok(result);
			}
			return BadRequest(ModelState);
		}

		[HttpPost]
		// ActionNameAttribute will be used to map the method to the name of action in Request URL
		// http://localhost:5001/apoi/CategoryBinderAPI/PostFromQuery?CategoryId=Cat55&CategoryName=ff&BasePrice=10&SubCategoryName=SC
		[ActionName("PostQuery")]
		public async Task<IActionResult> PostFromQuery([FromQuery] Categories input)
		{
			if (ModelState.IsValid)
			{
				var result = await catRepository.CreateAsync(input);
				return Ok(result);
			}
			return BadRequest(ModelState);
		}

		/// <summary>
		/// Route Template to send the POST data in Route Expressions
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("{CategoryId}/{CategoryName}/{BasePrice}/{SubCategoryName}")]
		// ActionNameAttribute will be used to map the method to the name of action in Request URL
		// http://localhost:5001/apoi/CategoryBinderAPI/PostFromRoute/Cat55/ff/10/SC
		[ActionName("PostRoute")]
		public async Task<IActionResult> PostFromRoute([FromRoute] Categories input)
		{
			if (ModelState.IsValid)
			{
				var result = await catRepository.CreateAsync(input);
				return Ok(result);
			}
			return BadRequest(ModelState);
		}


		[HttpPost]
		// ActionNameAttribute will be used to map the method to the name of action in Request URL
		// Data will be post from HTML FormModel
		[ActionName("PostForm")]
		public async Task<IActionResult> PostFromForm([FromForm] Categories input)
		{
			if (ModelState.IsValid)
			{
				var result = await catRepository.CreateAsync(input);
				return Ok(result);
			}
			return BadRequest(ModelState);
		}
	}
}
