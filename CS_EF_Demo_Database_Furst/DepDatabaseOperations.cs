using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Demo_Database_Furst
{
    /// <summary>
    /// The class implement the IDataOperations<TEntity, in TPk> generic interface
    /// TEntity is Dept class
    /// TPk in integer
    /// </summary>
    public class DepDatabaseOperations : IDataOperations<Dept, int>
    {
        // create an instace of the DbContext class i.e. ExpensesRHealEntities
        ExpensesRHealEntities ctx;

        public DepDatabaseOperations()
        {
            ctx = new ExpensesRHealEntities();
        }

        public Dept Create(Dept entity)
        {
            // add the entity object in DbSet<Dept>
            // The Add() method of DbSet<T> returns teh newly created entity
            entity = ctx.Depts.Add(entity);
            // commit trnsactions
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            // search the record based on id Primary key
            var dept = ctx.Depts.Find(id);
            // if the record is not found then Find() method will return null
            if (dept == null)
            {
                return false; 
            }
            // pass the searched record to Remove() method of DbSet<Dept>
            ctx.Depts.Remove(dept);
            // commit transactions
            ctx.SaveChanges();
            return true; // the delete is successful
        }

        public List<Dept> GetData()
        {
            // retuen all departments
            // the data is stored as Object Collection as Queryable inside the client's memory
            var depts = ctx.Depts.ToList();
            
            return depts;
        }

        public Dept GetData(int id)
        {
            var dept = ctx.Depts.Find(id);
            return dept;
        }

        public Dept Update(int id, Dept entity)
        {
            // search record based on P.K.
            var dept = ctx.Depts.Find(id);
            // update properties of searched record
            dept.DeptName = entity.DeptName;
            dept.Location = entity.Location;
            dept.Capacity = entity.Capacity;

            // commit trsanxtion
            ctx.SaveChanges();
            return dept; // return the updated record
        }
    }
}
