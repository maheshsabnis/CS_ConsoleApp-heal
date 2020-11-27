using MVC_Complete_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Complete_App.BizRepositories
{
    public class CategoryBizRepository : IBizRepository<Category, int>
    {
        RHealDbContext ctx;

        public CategoryBizRepository()
        {
            ctx = new RHealDbContext();
        }

        public Category Create(Category entity)
        {
            entity = ctx.Categories.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Categories.Find(id);
            if (res == null) return false;
            ctx.Categories.Remove(res);
            ctx.SaveChanges();
            return true;
        }

        public List<Category> GetData()
        {
            var res = ctx.Categories.ToList();
            return res;
        }

        public Category GetData(int id)
        {
            var res = ctx.Categories.Find(id);
            return res;
        }

        public Category Update(int id, Category entity)
        {
            var res = ctx.Categories.Find(id);
            if (res != null)
            {
                res.CategoryId = entity.CategoryId;
                res.CategoryName = entity.CategoryName;
                res.SubCategoryName = entity.SubCategoryName;
                res.BasePrice = entity.BasePrice;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }
    }
}