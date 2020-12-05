using ASPNET_Core_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_App.Repositories
{
	public class ProductBizRepository : IBizRepository<Products, int>
	{
		private readonly RHealDbContext _context;
		public ProductBizRepository(RHealDbContext context)
		{
			_context = context;
		}

		public async Task<Products> CreateAsync(Products entity)
		{
			// always decorate the async executing 
			// statement as "await", if the method
			// containing this statement is decorated as "async"
			var res = await _context.Products.AddAsync(entity);
			await _context.SaveChangesAsync();
			return res.Entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var result = await _context.Products.FindAsync(id);
			if (result == null) return false;
			_context.Products.Remove(result);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<List<Products>> GetDataAsync()
		{
			var records = await _context.Products.ToListAsync();
			return records;
		}

		public async Task<Products> GetDataAsync(int id)
		{
			var result = await _context.Products.FindAsync(id);
			return result;
		}

		public async Task<Products> UpdateAync(int id, Products entity)
		{
			var result = await _context.Products.FindAsync(id);
			if (result == null) return null;

			result.ProductId = entity.ProductId;
			result.ProductName = entity.ProductName;
			result.Manufacturer = entity.Manufacturer;
			result.Description = entity.Description;
			result.Price = entity.Price;
			result.CategoryRowId = entity.CategoryRowId;
			await _context.SaveChangesAsync();
			return result;

		}
	}
}
