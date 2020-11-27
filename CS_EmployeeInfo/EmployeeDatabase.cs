using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EmployeeInfo
{

    public class EmployeeDatabase : List<Employee>
    {
        public EmployeeDatabase()
        {
            Add(new Employee() {EmpNo=101,EmpName="A",Salary=30000 });
            Add(new Employee() { EmpNo = 102, EmpName = "B", Salary = 34000 });
        }
    }
}
