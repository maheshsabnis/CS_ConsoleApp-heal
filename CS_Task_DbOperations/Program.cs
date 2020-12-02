using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CS_Task_DbOperations
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine("Starting from Main Caller");

			Task taskInsertDept = new Task(()=> BulkInsertDept());
			taskInsertDept.Start();

			Task taskInsertEmp = new Task(()=> BulkInsertEmp());
			taskInsertEmp.Start();


			Console.WriteLine("Done wit the Caller");
			taskInsertDept.Wait();
			taskInsertEmp.Wait();
			Console.ReadLine();
		}


		static void BulkInsertDept()
		{
			Console.WriteLine($"Inserting Bulk for Department started at {DateTime.Now.ToString()}");
			var sw = Stopwatch.StartNew();
			SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
			Conn.Open();
			SqlCommand Cmd = new SqlCommand();
			Cmd.Connection = Conn;

			foreach (var dept in new Depts())
			{
				Cmd.CommandText = $"Insert into Department values({dept.DeptNo},'{dept.DeptName}','{dept.Location}')";
				 
				Cmd.ExecuteNonQuery();
				  
			}
			

			Conn.Close();
			Console.WriteLine($"Bulk insert for Department is completed at {DateTime.Now.ToString()} and taken" +
				$" {sw.Elapsed.TotalSeconds} Seconds to complete");
		}

		static void BulkInsertEmp()
		{

			Console.WriteLine($"Inserting Bulk for Employee started at {DateTime.Now.ToString()}");
			var sw = Stopwatch.StartNew();
			SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
			Conn.Open();
			SqlCommand Cmd = new SqlCommand();
			Cmd.Connection = Conn;

			foreach (var emp in new Emps())
			{
				Cmd.CommandText = $"Insert into Employee values({emp.EmopNo}, '{emp.EmpName}', '{emp.Designation}',{emp.Salary}, {emp.DeptNo})";
				 
				Cmd.ExecuteNonQuery();
				 
			}


			Conn.Close();
			Console.WriteLine($"Bulk insert for Employee is completed at {DateTime.Now.ToString()} and taken" +
				$" {sw.Elapsed.TotalSeconds} Seconds to complete");
		}



	}

	public class Dept
	{
		public int DeptNo { get; set; }
		public string DeptName { get; set; }
		public string Location { get; set; }
	}

	public class Depts : List<Dept>
	{
		public Depts()
		{
			Add(new Dept() {DeptNo=101,DeptName="Dept_101", Location="Mumbai" });
			Add(new Dept() { DeptNo = 102, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 103, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 104, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 105, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 106, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 107, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 108, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 109, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 110, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 111, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 112, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 113, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 114, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 115, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 116, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 117, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 118, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 119, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 120, DeptName = "Dept_101", Location = "Mumbai" });
		}
	}

	public class Emp
	{
		public int EmopNo { get; set; }
		public string EmpName { get; set; }
		public string Designation { get; set; }
		public int Salary { get; set; }
		public int DeptNo { get; set; }
	}

	public class Emps : List<Emp>
	{
		public Emps()
		{
			Add(new Emp() {EmopNo=301, EmpName="Emp_301", Designation="Desig_301",Salary=3000, DeptNo=10 });
			Add(new Emp() { EmopNo = 302, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 20 });
			Add(new Emp() { EmopNo = 303, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 30 });
			Add(new Emp() { EmopNo = 304, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 40 });
			Add(new Emp() { EmopNo = 305, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 50 });
			Add(new Emp() { EmopNo = 306, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 10 });
			Add(new Emp() { EmopNo = 307, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 20 });
			Add(new Emp() { EmopNo = 308, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 30 });
			Add(new Emp() { EmopNo = 309, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 40 });
			Add(new Emp() { EmopNo = 310, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 50 });
			Add(new Emp() { EmopNo = 311, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 10 });
			Add(new Emp() { EmopNo = 312, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 20 });
			Add(new Emp() { EmopNo = 313, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 30 });
			Add(new Emp() { EmopNo = 314, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 40 });
			Add(new Emp() { EmopNo = 315, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 50 });
			Add(new Emp() { EmopNo = 316, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 50 });
			Add(new Emp() { EmopNo = 317, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 40 });
			Add(new Emp() { EmopNo = 318, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 30 });
			Add(new Emp() { EmopNo = 319, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 20 });
			Add(new Emp() { EmopNo = 320, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 10 });
			Add(new Emp() { EmopNo = 321, EmpName = "Emp_301", Designation = "Desig_301", Salary = 3000, DeptNo = 50 });

		}
	}
}


