using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS_StoredProcs
{
    // Declare classes Dept and Emp. These classes will have properties 
    // mapped with Dept and Emp Tables in SQl Server ExpensesRHeal Database
    // The advantage of this approach is the CRUD operation will Read / Write data using 
    // these tables
    
    public class Dept
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

    }

    public class Emp
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
        public int DeptNo { get; set; }
    }
}
