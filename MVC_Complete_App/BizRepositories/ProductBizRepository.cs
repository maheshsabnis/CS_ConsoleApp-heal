using MVC_Complete_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Complete_App.BizRepositories
{
    public class ProductBizRepository : IBizRepository<Product, int>
    {
        RHealDbContext ctx;

        public ProductBizRepository()
        {
            ctx = new RHealDbContext();
        }

        public Product Create(Product entity)
        {
            entity = ctx.Products.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Products.Find(id);
            if (res == null) return false;
            ctx.Products.Remove(res);
            ctx.SaveChanges();
            return true;
        }

        public List<Product> GetData()
        {
            var res = ctx.Products.ToList();
            return res;
        }

        public Product GetData(int id)
        {
            var res = ctx.Products.Find(id);
            return res;
        }

        public Product Update(int id, Product entity)
        {
            var res = ctx.Products.Find(id);
            if (res != null)
            {
                res.ProductId = entity.ProductId;
                res.ProductName = entity.ProductName;
                res.Manufacturer = entity.Manufacturer;
                res.Description = entity.Description;
                res.CategoryRowId = entity.CategoryRowId;
                res.Price = entity.Price;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }
    }
}