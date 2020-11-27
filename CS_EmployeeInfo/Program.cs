using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EmployeeInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee() ;
            EmployeeDataOperations operations = new EmployeeDataOperations();
            // list of Employees
            var employees = operations.GetEmployees();
            Console.WriteLine("List of Employees");
            foreach (var item in employees)
            {
                Console.WriteLine($"{item.EmpNo}  {item.EmpName} {item.Salary}");
            }
            Console.WriteLine();
            Console.WriteLine("Add New Employee Details ");
            Console.WriteLine("EmpNo=");
            emp.EmpNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("EmpNAme = ");
            emp.EmpName = Console.ReadLine();
            Console.WriteLine("Salary = ");
            emp.Salary = Convert.ToInt32(Console.ReadLine());
            // adding new employee
            employees = operations.AddEmployee(emp);
            Console.WriteLine("List of Employees aftre addiung new record");
            foreach (var item in employees)
            {
                Console.WriteLine($"{item.EmpNo}  {item.EmpName} {item.Salary}");
            }
            Console.ReadLine();
        }
    }
}
