using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS_Collections
{
	class Program
	{
		static void Main(string[] args)
		{
			SequentialExecution();
			Console.WriteLine();
			Console.WriteLine();
			ParallelExecution();
			Console.ReadLine();
		}

		static void SequentialExecution()
		{
			var emps = new Employees();
			Console.WriteLine($"Sequential Exection Starts at = {DateTime.Now}");
			var startTime = Stopwatch.StartNew();
			foreach (Employee emp in emps)
			{
				CalaulcateTax(emp);
			}

			double totalTimeToExecuteLoop =
				   startTime.Elapsed.TotalSeconds;
			Console.WriteLine($"Sequential Execution stops at {DateTime.Now} and" +
				$" Total Time to execute loop = {totalTimeToExecuteLoop}");
		}

		static void ParallelExecution()
		{
			var emps = new Employees();
			Console.WriteLine($"Parallel Exection Starts at = {DateTime.Now}");
			var startTime = Stopwatch.StartNew();
			// starts from 0th record goes to the last record in
			// collection
			Parallel.For(0, emps.Count, count =>
			{
				CalaulcateTax(emps[count]);
			});

			double totalTimeToExecuteLoop =
				   startTime.Elapsed.TotalSeconds;
			Console.WriteLine($"Parallel Execution stops at {DateTime.Now} and" +
				$" Total Time to execute loop = {totalTimeToExecuteLoop}");
		}



		static void CalaulcateTax(Employee employee)
		{
			Thread.Sleep(500);
			employee.TDS = employee.Salary * 0.2;
			Console.WriteLine($"Tax of EmpNo {employee.EmpNo} = {employee.TDS}");
		}

	}
}
