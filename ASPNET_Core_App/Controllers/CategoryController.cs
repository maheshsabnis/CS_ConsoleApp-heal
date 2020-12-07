using ASPNET_Core_App.Models;
using ASPNET_Core_App.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ASPNET_Core_App.TempdataExtension;
using Microsoft.AspNetCore.Http;
namespace ASPNET_Core_App.Controllers
{
	/// <summary>
	/// Controller, the base class for MVC controllers
	/// THis is derived from "ControllerBase" abstract class
	/// The "ControllerBase" is a Common base class for
	/// MVC Controller and API Controllers in ASP.NET Core
	/// </summary>
	public class CategoryController : Controller
	{
		private readonly IBizRepository<Categories, int> catRepository;

		/// <summary>
		/// Injected the Repository in Constructor
		/// </summary>
		/// <param name="repository"></param>
		public CategoryController(IBizRepository<Categories, int> repository)
		{
			catRepository = repository;
		}

		/// <summary>
		///  IActionResult is a common contract interface for returnig
		///  ViewResult(), PartialViewresult(), OkResult(), OkObjectResult()
		///  Returns type for MVC Controller Action  methods and 
		///  API Controller Action methods
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> Index()
		{
			var result = await catRepository.GetDataAsync();

			return View(result);
		}

		public IActionResult Create()
		{
			return View(new Categories());		
		}

		[HttpPost]
		public async Task<IActionResult> Create(Categories data)
		{
			//try
			//{
				if (ModelState.IsValid)
				{
					if (data.BasePrice < 0) throw new Exception("Base Price Cannot be -ve");
					data = await catRepository.CreateAsync(data);
					return RedirectToAction("Index");
				}
				return View(data);
			//}
			//catch (Exception ex)
			//{
			//	return View("Error", new ErrorViewModel()
			//	{
			//		 ControllerName = this.RouteData.Values["controller"].ToString(),
			//		 ActionName = this.RouteData.Values["action"].ToString(),
			//		 ErrorMessage =ex.Message
			//	}); 
			//}
		}

		public  async Task<IActionResult> Edit(int id)
		{
			var res = await catRepository.GetDataAsync(id);
			return View(res);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, Categories data)
		{
			if (ModelState.IsValid)
			{
				data = await catRepository.UpdateAync(id,data);
				return RedirectToAction("Index");
			}
			return View(data);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var res = await catRepository.DeleteAsync(id);
			return RedirectToAction("Index");
		}

		public IActionResult ShowDetails(int id)
		{

			Categories cat = catRepository.GetDataAsync(id).Result;
			//TempData.SetData<Categories>("Cat", cat);


			//TempData["CatRowId"] = id;
			HttpContext.Session.SetInt32("CatId", id);
				
			return RedirectToAction("Index", "Product");
		}
	}
}
