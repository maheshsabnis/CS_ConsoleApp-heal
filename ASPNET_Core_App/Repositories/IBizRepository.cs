using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPNET_Core_App.Repositories
{
   /// <summary>
   /// Repository interface contains Asynchronous
   /// Methods
   /// </summary>
   /// <typeparam name="TEntity"></typeparam>
   /// <typeparam name="TPk"></typeparam>
    public interface IBizRepository<TEntity, in TPk> where TEntity : class
    {
        Task<List<TEntity>> GetDataAsync();
        Task<TEntity> GetDataAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAync(TPk id, TEntity entity);
        Task<bool> DeleteAsync(TPk id);
    }
}
