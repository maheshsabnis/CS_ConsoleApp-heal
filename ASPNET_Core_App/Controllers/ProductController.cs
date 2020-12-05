using ASPNET_Core_App.Models;
using ASPNET_Core_App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_Core_App.TempdataExtension;

namespace ASPNET_Core_App.Controllers
{
	public class ProductController : Controller
	{
		private readonly IBizRepository<Products, int> prdRepository;
		private readonly IBizRepository<Categories, int> catRepository;
		/// <summary>
		/// Injected the Repository in Constructor
		/// </summary>
		/// <param name="repository"></param>
		public ProductController(IBizRepository<Products, int> repository, IBizRepository<Categories, int> catRepo)
		{
			prdRepository = repository;
			catRepository = catRepo;
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
			List<Products> result = new List<Products>();
			if (TempData.Keys.Count > 0)
			{
				var cat = TempData.GetData<Categories>("Cat");
				var id = Convert.ToInt32(TempData["CatRowId"]);
				result = prdRepository.GetDataAsync().Result.ToList().Where(p => p.CategoryRowId == id).ToList();
			}
			else
			{ 
				result = await prdRepository.GetDataAsync();
			}
			

			return View(result);
		}

		public IActionResult Create()
		{
			ViewData["CategoryRowId"] = catRepository.GetDataAsync().Result;
			return View(new Products());
		}

		[HttpPost]
		public async Task<IActionResult> Create(Products data)
		{
			if (ModelState.IsValid)
			{
				data = await prdRepository.CreateAsync(data);
				return RedirectToAction("Index");
			}
			ViewData["CategoryRowId"] = catRepository.GetDataAsync().Result;
			return View(data);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var res = await prdRepository.GetDataAsync(id);
			return View(res);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, Products data)
		{
			if (ModelState.IsValid)
			{
				data = await prdRepository.UpdateAync(id, data);
				return RedirectToAction("Index");
			}
			return View(data);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var res = await prdRepository.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}
}
