using ASPNET_Core_App.Models;
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

		public Task<Products> CreateAsync(Products entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Products>> GetDataAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Products> GetDataAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Products> UpdateAync(int id, Products entity)
		{
			throw new NotImplementedException();
		}
	}
}
