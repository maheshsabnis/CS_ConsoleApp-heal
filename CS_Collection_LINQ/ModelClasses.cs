using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Collection_LINQ
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
    }


    public class EmployeeDatabase : List<Employee>
    {
        public EmployeeDatabase()
        {
            Add(new Employee() {EmpNo=1,EmpName="Amit",
                Department="D1",Designation="Manager",Salary=400000 });
            Add(new Employee()
            {
                EmpNo = 11,
                EmpName = "Kumar",
                Department = "D1",
                Designation = "Manager",
                Salary = 600000
            });
            Add(new Employee()
            {
                EmpNo = 2,
                EmpName = "Ajay",
                Department = "D1",
                Designation = "Lead",
                Salary = 40000
            });
            Add(new Employee()
            {
                EmpNo = 3,
                EmpName = "Akash",
                Department = "D1",
                Designation = "Developer",
                Salary = 4000
            });
            Add(new Employee()
            {
                EmpNo = 4,
                EmpName = "Mahesh",
                Department = "D2",
                Designation = "Manager",
                Salary = 400000
            });
            Add(new Employee()
            {
                EmpNo = 5,
                EmpName = "Mukesh",
                Department = "D2",
                Designation = "Lead",
                Salary = 40000
            });
            Add(new Employee()
            {
                EmpNo = 6,
                EmpName = "Mohan",
                Department = "D2",
                Designation = "Developer",
                Salary = 4000
            });
            Add(new Employee()
            {
                EmpNo = 7,
                EmpName = "Chaitanya",
                Department = "D3",
                Designation = "Manager",
                Salary = 40000
            });
            Add(new Employee()
            {
                EmpNo = 8,
                EmpName = "Chinmay",
                Department = "D3",
                Designation = "Lead",
                Salary = 40000
            });
            Add(new Employee()
            {
                EmpNo = 9,
                EmpName = "Chirag",
                Department = "D3",
                Designation = "Operator",
                Salary = 4000
            });
            Add(new Employee()
            {
                EmpNo = 10,
                EmpName = "Ankita",
                Department = "D1",
                Designation = "Enginerr",
                Salary = 50000
            });
        }
    }
}
