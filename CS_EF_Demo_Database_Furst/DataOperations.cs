using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Demo_Database_Furst
{
    /// <summary>
    /// The multi-type generic interface because this interface accepts two type parameters
    /// TEntity --> This will always be a class because ethis is applied with constraints "where TEntity : class"
    /// TPk --> This is represented as 'in' mes the input parameter. This will always be input value type
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPk"></typeparam>

    public interface IDataOperations<TEntity, in TPk> where TEntity : class
    {
        // This method will return list of TEntity
        List<TEntity> GetData();
        // This method will return a single TEntity object  based on TPk value
        TEntity GetData(TPk id);
        // Create a new object based on the TEntity object values
        // the newly created TEntity will be returned
        TEntity Create(TEntity entity);
        // will update the TEntity by searching the data based on TPk Value
        // the updated entity will be returned
        TEntity Update(TPk id, TEntity entity);
        // delete the record based on value of TPk
        // if the entity is deleted based on TPk the the boolean true will be returned else false will be returned
        bool Delete(TPk id);
    }

    
}
