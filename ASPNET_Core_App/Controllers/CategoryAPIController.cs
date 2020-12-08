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
	/// APIs in .NET Core uses Attribute routing by default
	/// </summary>
	[Route("api/[controller]")]
	[ApiController] // class used to map posted JSON data in body to CLR object
	public class CategoryAPIController : ControllerBase
	{
		// inject the repositoryn in the controller

		private readonly IBizRepository<Categories, int> catRepository;
		public CategoryAPIController(IBizRepository<Categories, int> repository)
		{
			catRepository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var result = await catRepository.GetDataAsync();
			return Ok(result); // response will be serialized in JSON format
		}
		/// <summary>
		/// The HttpGet with the  Route Parameter
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var result = await catRepository.GetDataAsync(id);
			if (result != null) return Ok(result); // response will be serialized in JSON format

			return NotFound($"  Record with  {id} is not found ");
		}
		[HttpPost]
		public async Task<IActionResult> Post(Categories input)
		{
			if (ModelState.IsValid)
			{
				if (input.BasePrice < 0) throw new Exception("BasePrice cannoty be -Ve");
				var result = await catRepository.CreateAsync(input);
				return Ok(result);
			}
			return BadRequest(ModelState);
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Categories input)
		{
			if (ModelState.IsValid)
			{
				var result = await catRepository.UpdateAync(id,input);
				return Ok(result);
			}
			return BadRequest(ModelState);
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Detele(int id)
		{
			var result = await catRepository.DeleteAsync(id);
			if(result) return Ok($"  Record with  {id} is deleted successfully {result}");
			return NotFound($"  Record with  {id} is not found so result of delete operation is {result}");
		}
	}
}
