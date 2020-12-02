using System;
using System.Threading;
using System.Threading.Tasks;

namespace CS_Task_Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			// the main thread on which Main() method is executing
			Thread.CurrentThread.Name = "Main Thread";
			Console.WriteLine($"Starts from the Threads " +
				$"{Thread.CurrentThread.Name}");
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine($"In Sync Execution {i} before Async call");
			}

			// Synchronous Execution  for PrintMeassage() method
			// PrintMessage();

			// Define a Task
			// the task accepts long running process to execute
			// asynchronously on different thread
			Task taskPrint = new Task(()=> PrintMessage());
			// start the task
			taskPrint.Start();

			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine($"In Sync Execution {i} After Async  call");
			}
			Console.WriteLine($"The Main thread is completing task " +
				$"{Thread.CurrentThread.Name}");
			// wait for the task to complete the execution
			taskPrint.Wait();
			Console.ReadLine();
		}

		static void PrintMessage()
		{
			Thread.CurrentThread.Name = "Message Thread";
			// wait for 1 Second
			Thread.Sleep(5000);
			Console.WriteLine($"I am running on Task {Thread.CurrentThread.Name}");
		}
	}
}
