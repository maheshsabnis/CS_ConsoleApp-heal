using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Parallel_Invoke
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
	public class Product
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public double Price { get; set; }
		public double SalesPrice { get; set; }
	}

	public class Products : List<Product>
	{
		public Products()
		{
			Add(new Product() { ProductId = 1, ProductName = "P1", Price = 2000 });
			Add(new Product() { ProductId = 2, ProductName = "P2", Price = 2100 });
			Add(new Product() { ProductId = 3, ProductName = "P3", Price = 2400 });
			Add(new Product() { ProductId = 4, ProductName = "P4", Price = 2500 });
			Add(new Product() { ProductId = 5, ProductName = "P5", Price = 26000 });
			Add(new Product() { ProductId = 6, ProductName = "P6", Price = 2070 });
			Add(new Product() { ProductId = 7, ProductName = "P7", Price = 2050 });
			Add(new Product() { ProductId = 8, ProductName = "P8", Price = 2030 });
			Add(new Product() { ProductId = 9, ProductName = "P9", Price = 2400 });
			Add(new Product() { ProductId = 10, ProductName = "P10", Price = 2050 });
			Add(new Product() { ProductId = 11, ProductName = "P11", Price = 2080 });
			Add(new Product() { ProductId = 12, ProductName = "P12", Price = 2030 });
			Add(new Product() { ProductId = 13, ProductName = "P13", Price = 2020 });
			Add(new Product() { ProductId = 14, ProductName = "P14", Price = 2100 });
			Add(new Product() { ProductId = 15, ProductName = "P15", Price = 2200 });
			Add(new Product() { ProductId = 16, ProductName = "P16", Price = 2300 });
			Add(new Product() { ProductId = 17, ProductName = "P17", Price = 2400 });
			Add(new Product() { ProductId = 18, ProductName = "P18", Price = 2500 });
			Add(new Product() { ProductId = 19, ProductName = "P19", Price = 2600 });
			Add(new Product() { ProductId = 20, ProductName = "P21", Price = 2700 });
			Add(new Product() { ProductId = 21, ProductName = "P21", Price = 2700 });
		}
	}
}
