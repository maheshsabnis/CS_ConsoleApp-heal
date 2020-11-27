using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_StoredProcs
{
    class Program
    {
        static void Main(string[] args)
        {

            DataAccessStoredProcs ds = new DataAccessStoredProcs();

            List<Emp> emps = new List<Emp>();

            emps = ds.GetEmployees();

            foreach (var item in emps)
            {
                Console.WriteLine($"{item.EmpNo} {item.EmpName}");
            }


            Console.WriteLine();
            //Console.WriteLine("Insert Employee Information");
            //Emp emp = new Emp();
            //emp.EmpNo = Convert.ToInt32(Console.ReadLine());
            //emp.EmpName = Console.ReadLine();
            //emp.Designation = Console.ReadLine();
            //emp.Salary = Convert.ToInt32(Console.ReadLine());
            //emp.DeptNo = Convert.ToInt32(Console.ReadLine());

            //int result = ds.InsertEmployee(emp);
            //Console.WriteLine($"Result Received {result}");
            //Console.WriteLine();
            //Console.WriteLine("List of Employees After insert");
            //emps = ds.GetEmployees();

            //foreach (var item in emps)
            //{
            //    Console.WriteLine($"{item.EmpNo} {item.EmpName}");
            //}
            //Console.WriteLine();

            Console.WriteLine("Enter DeptName");
            string deptName = Console.ReadLine();
            int receivedSalarySum = ds.GetSumOfSalariesByDeptName(deptName);
            Console.WriteLine($"Sum of Salary for DeptName {deptName} = {receivedSalarySum}");

            Console.ReadLine();
        }
    }
}
