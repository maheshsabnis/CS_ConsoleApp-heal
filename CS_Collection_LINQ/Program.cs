using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Collection_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Commented Code
            /*
            #region  Collections with Boxing and UnBoxing
         

            ArrayList arr = new ArrayList();
            arr.Add(10);
            arr.Add(20);
            arr.Add(30);
            arr.Add("A");
            arr.Add("B");
            arr.Add("C");
            arr.Add('a');
            arr.Add('b');
            arr.Add('c');
            arr.Add(10.349);
            arr.Add(20.45);
            arr.Add(30.7);
            arr.Add(new Employee() {EmpNo=101,EmpName="Mahesh" });
            arr.Add(new Employee() { EmpNo = 102, EmpName = "Tejas" });
            arr.Add(new Employee() { EmpNo = 103, EmpName = "Jay" });
            foreach (var entry in arr)
            {
                // print only integers
                // run time unboxing
                if (entry.GetType() == typeof(int))
                { 
                    Console.WriteLine(entry);
                }
                // print only string
                // run time unboxing
                if (entry.GetType() == typeof(string))
                {
                    Console.WriteLine(entry);
                }
                // print only char
                // run time unboxing
                if (entry.GetType() == typeof(char))
                {
                    Console.WriteLine(entry);
                }
                // print only double
                // run time unboxing
                if (entry.GetType() == typeof(double))
                {
                    Console.WriteLine(entry);
                }
                // print only Employee
                // run time unboxing
                if (entry.GetType() == typeof(Employee))
                {
                    Console.WriteLine(((Employee)entry).EmpNo + "  " + ((Employee)entry).EmpName);
                }
            }
            #endregion

            #region Using Generics
            
            List<int> intList = new List<int>();
            intList.Add(10);
            intList.Add(20);
            intList.Add(30);

            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }

            List<string> strList = new List<string>();
            strList.Add("A"); strList.Add("B"); strList.Add("C");
            foreach (string item in strList)
            {
                Console.WriteLine(item);
            }

            List<Employee> lstEmp = new List<Employee>();
            lstEmp.Add(new Employee() { EmpNo = 101, EmpName = "James Bond" });
            lstEmp.Add(new Employee() { EmpNo = 102, EmpName = "Ethon Hunt" });
            lstEmp.Add(new Employee() { EmpNo = 103, EmpName = "Indiana Jones" });
            lstEmp.Add(new Employee() { EmpNo = 101, EmpName = "Jason Bourn" });
            foreach (Employee item in lstEmp)
            {
                Console.WriteLine(item.EmpNo + "  " + item.EmpName);
            }

            #endregion

            */
            #endregion


            var empDatabase = new EmployeeDatabase();

            #region Declarative Form of LINQ


            // list all Managers
            foreach (Employee item in empDatabase)
            {
                if (item.Designation == "Manager" && item.Department=="D1" && item.Salary > 450000)
                {
                    Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Department}" +
                        $" {item.Designation} {item.Salary}");   
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            // Declarative Query
            // 1. read all managers

            var managers = empDatabase.Where(e=>e.Designation == "Manager");
            Console.WriteLine("Managers Are");
            foreach (var item in managers)
            {
                PrintResult(item);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Result Otrder By EmpName");
            var orderByEmpName = empDatabase.OrderBy(e=>e.EmpName);
            foreach (var item in orderByEmpName)
            {
                PrintResult(item);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Salary More than 3 L");
            var salaryMoreThan3L = empDatabase.Where(e => e.Salary > 300000);
            foreach (var item in salaryMoreThan3L)
            {
                PrintResult(item);
            }

            #endregion


            Console.WriteLine();
            Console.WriteLine();
            #region Imperative Queries
            var onlyManagers = from e in empDatabase
                               where e.Designation == "Manager"
                               select e;
            Console.WriteLine("Imperative Managers");
            foreach (var item in onlyManagers)
            {
                PrintResult(item);
            }
            Console.WriteLine();
            Console.WriteLine();
            var salartgreaterthan3L = from e in empDatabase
                               where e.Salary > 300000
                               select e;
            Console.WriteLine("Imperative Salary greater than 3L");
            foreach (var item in salartgreaterthan3L)
            {
                PrintResult(item);
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Departmentwise Total Salary");
            var groupByDeptName = from e in empDatabase
                                  group e by e.Department into dept // group of all departments
                                  select new // a anonymous class
                                  {
                                      // Key is the property on whihc Group is created
                                      DeptName =  dept.Key, // Department Name
                                      TotalSalary = dept.Sum(e=>e.Salary)  // Sum of Salaries
                                  };
                                  
                                      
            Console.WriteLine("Imperative Group by DeptName");
            foreach (var item in groupByDeptName)
            {
                Console.WriteLine($"Emp Record {item.DeptName} {item.TotalSalary}");
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Order By EmpName");

            var OrderBuEmpName = from e in empDatabase
                                 orderby e.EmpName
                                 select e;


            foreach (var item in OrderBuEmpName)
            {
                PrintResult(item);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Order By EmpName Descending");

            var OrderBuEmpNameDescending = from e in empDatabase
                                 orderby e.EmpName descending
                                 select e;


            foreach (var item in OrderBuEmpNameDescending)
            {
                PrintResult(item);
            }






            #endregion





            Console.ReadLine();
        }

        static void PrintResult(Employee item)
        {
            Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Department}" +
                        $" {item.Designation} {item.Salary}");
        }
    }

    


}

