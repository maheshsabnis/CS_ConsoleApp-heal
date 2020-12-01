using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Collections
{
	public class Employee
	{
		public int EmpNo { get; set; }
		public string EmpName { get; set; }
		public int Salary { get; set; }
		public double TDS { get; set; }
	}


	public class Employees : List<Employee>
	{
		public Employees()
		{
			Add(new Employee() { EmpNo = 101, EmpName = "A", Salary = 3200 });
			Add(new Employee() { EmpNo = 102, EmpName = "B", Salary = 3200 });
			Add(new Employee() { EmpNo = 103, EmpName = "C", Salary = 3300 });
			Add(new Employee() { EmpNo = 104, EmpName = "D", Salary = 3400 });
			Add(new Employee() { EmpNo = 105, EmpName = "E", Salary = 3500 });
			Add(new Employee() { EmpNo = 106, EmpName = "F", Salary = 3600 });
			Add(new Employee() { EmpNo = 107, EmpName = "G", Salary = 3700 });
			Add(new Employee() { EmpNo = 108, EmpName = "H", Salary = 3800 });
			Add(new Employee() { EmpNo = 109, EmpName = "I", Salary = 3900 });
			Add(new Employee() { EmpNo = 110, EmpName = "J", Salary = 3900 });
			Add(new Employee() { EmpNo = 111, EmpName = "K", Salary = 3800 });
			Add(new Employee() { EmpNo = 112, EmpName = "L", Salary = 3700 });
			Add(new Employee() { EmpNo = 113, EmpName = "M", Salary = 3600 });
			Add(new Employee() { EmpNo = 114, EmpName = "N", Salary = 3500 });
			Add(new Employee() { EmpNo = 116, EmpName = "O", Salary = 3400 });
			Add(new Employee() { EmpNo = 116, EmpName = "P", Salary = 3300 });
			Add(new Employee() { EmpNo = 117, EmpName = "Q", Salary = 3200 });
			Add(new Employee() { EmpNo = 118, EmpName = "R", Salary = 3100 });
			Add(new Employee() { EmpNo = 119, EmpName = "S", Salary = 3200 });
			Add(new Employee() { EmpNo = 120, EmpName = "T", Salary = 3400 });
			Add(new Employee() { EmpNo = 121, EmpName = "U", Salary = 3600 });
			Add(new Employee() { EmpNo = 122, EmpName = "V", Salary = 3800 });
			Add(new Employee() { EmpNo = 123, EmpName = "W", Salary = 3800 });
			Add(new Employee() { EmpNo = 124, EmpName = "X", Salary = 3200 });
			Add(new Employee() { EmpNo = 125, EmpName = "Y", Salary = 3400 });
			Add(new Employee() { EmpNo = 126, EmpName = "Z", Salary = 3600 });
		}
	}


	
}
