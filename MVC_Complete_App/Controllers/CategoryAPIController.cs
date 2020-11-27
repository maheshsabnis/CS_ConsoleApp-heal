using MVC_Complete_App.BizRepositories;
using MVC_Complete_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_Complete_App.Controllers
{
    public class CategoryAPIController : ApiController
    {
		IBizRepository<Category, int> catRepository;
		public CategoryAPIController()
		{
			catRepository = new CategoryBizRepository();
		}

		/// <summary>
		/// http://localhost:<PORT>/api/CategoryAPI
		/// </summary>
		/// <returns></returns>
		public IHttpActionResult Get()
		{
			var result = catRepository.GetData();
			return Ok(result);
		}

		/// <summary>
		/// http://localhost:<PORT>/api/CategoryAPI/{id}
		/// </summary>
		/// <returns></returns>
		public IHttpActionResult Get(int id)
		{
			var result = catRepository.GetData(id);
			return Ok(result);
		}

		/// <summary>
		/// http://localhost:<PORT>/api/CategoryAPI
		/// </summary>
		/// <returns></returns>
		public IHttpActionResult Post(Category data)
		{
			if (ModelState.IsValid)
			{
				var result = catRepository.Create(data);
				return Ok(data); 
			}
			// if the Model is invalid the return vaidation error messages
			return BadRequest(ModelState);
		}

		/// <summary>
		/// http://localhost:<PORT>/api/CategoryAPI/{id}
		/// </summary>
		/// <returns></returns>
		public IHttpActionResult Put(int id, Category data)
		{
			if (ModelState.IsValid)
			{
				var result = catRepository.Update(id,data);
				return Ok(data);
			}
			// if the Model is invalid the return vaidation error messages
			return BadRequest(ModelState);
		}

		/// <summary>
		/// http://localhost:<PORT>/api/CategoryAPI/{id}
		/// </summary>
		/// <returns></returns>
		public IHttpActionResult Delete(int id)
		{
			var result = catRepository.Delete(id);
			return Ok(result);
		}
	}
}
