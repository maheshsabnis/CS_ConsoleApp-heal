using ASPNET_Core_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_App.Repositories
{
	public class CategoryBizRepository : IBizRepository<Categories, int>
	{
		// Inject the DbCOntext in the Repository class
		// using Constructor  Injection

		private readonly RHealDbContext _context;

		public CategoryBizRepository(RHealDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// The "async" means the method is asynchronously executed
		/// This method "must contains" at lease one "awaitable" call
		/// This means that the async executing method will wait for
		/// the thread to complete the async call
		/// All awaitable calls will be executed parallelly
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public async Task<Categories> CreateAsync(Categories entity)
		{
			// always decorate the async executing 
			// statement as "await", if the method
			// containing this statement is decorated as "async"
			var res = await _context.Categories.AddAsync(entity);
			await _context.SaveChangesAsync();
			return res.Entity; 
		}

		public  async Task<bool> DeleteAsync(int id)
		{
			var result = await _context.Categories.FindAsync(id);
			if (result == null) return false;
			_context.Categories.Remove(result);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<List<Categories>> GetDataAsync()
		{
			var records = await _context.Categories.ToListAsync();
			return records;
		}

		public  async Task<Categories> GetDataAsync(int id)
		{
			var result = await _context.Categories.FindAsync(id);
			return result;
		}

		public async Task<Categories> UpdateAync(int id, Categories entity)
		{
			var result = await _context.Categories.FindAsync(id);
			if(result == null) return null;

			result.CategoryId = entity.CategoryId;
			result.CategoryName = entity.CategoryName;
			result.SubCategoryName = entity.SubCategoryName;
			result.BasePrice = entity.BasePrice;
			await _context.SaveChangesAsync();
			return result;

		}
	}
}
