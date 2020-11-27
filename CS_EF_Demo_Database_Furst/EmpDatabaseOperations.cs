using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Demo_Database_Furst
{
    public class EmpDatabaseOperations : IDataOperations<Emp, int>
    {
        public Emp Create(Emp entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Emp> GetData()
        {
            throw new NotImplementedException();
        }

        public Emp GetData(int id)
        {
            throw new NotImplementedException();
        }

        public Emp Update(int id, Emp entity)
        {
            throw new NotImplementedException();
        }
    }
}
