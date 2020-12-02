using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS_Multiple_Taskxs
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("OPerations in Main");

			Task taskPrintMessages = new Task(()=> PrintMessage());

			Task taskDbOperations = new Task(()=> BulkInsertDept());

			Task taskReverString = new Task(()=> ReverseString());

			taskPrintMessages.Start();
			taskDbOperations.Start();
			taskReverString.Start();


			Task.WaitAll(taskPrintMessages, taskReverString, taskDbOperations);

			Console.WriteLine("Main Over");
			Console.ReadLine();
		}

		static void PrintMessage()
		{
			Console.WriteLine($"Print Message Starts at {DateTime.Now.ToString()}");
			var sw = Stopwatch.StartNew();
			for (int i = 0; i < 10; i++)
			{
				Thread.Sleep(1000);
				Console.WriteLine($"The Message = {i}");
			}

			Console.WriteLine($"Print Message is completed at {DateTime.Now.ToString()} and taken" +
				$" {sw.Elapsed.TotalSeconds} Seconds to complete");
		}

		static void ReverseString()
		{

			Console.WriteLine($"Reverse String Starts at {DateTime.Now.ToString()}");
			var sw = Stopwatch.StartNew();
			string str = $"Sir Sean Connery (25 August 1930 – 31 October 2020) was a Scottish actor. " +
				$"He gained recognition as the first actor to portray fictional British secret agent " +
				$"James Bond in film, starring in seven Bond films between 1962 and 1983.[1][2][3] " +
				$"Originating the role in Dr. No, Connery played Bond in six of Eon Productions' " +
				$"entries and made his final appearance in the Jack Schwartzman-produced Never Say Never Again." +
				$"Connery began acting in smaller theatre and television productions until his breakout " +
				$"role as Bond.Although he did not enjoy the off-screen attention the role gave him, " +
				$"the success brought offers from famed film directors such as Alfred Hitchcock, " +
				$"Sidney Lumet and John Huston.Those films included Marnie(1964), The Hill(1965), " +
				$"Murder on the Orient Express(1974), The Man Who Would Be King(1975), A Bridge Too Far(1977)," +
				$" Highlander(1986), The Name of the Rose(1986), The Untouchables(1987), Indiana Jones and the " +
				$"Last Crusade(1989), The Hunt for Red October (1990), Dragonheart (1996), The Rock(1996), " +
				$"and Finding Forrester(2000).Connery officially retired from acting in 2006, although he" +
				$" briefly returned for voice over roles in 2012.His achievements in film were recognised " +
				$"with an Academy Award, two BAFTA Awards(including the BAFTA Fellowship), " +
				$"and three Golden Globes, including the Cecil B.DeMille Award and a Henrietta Award.In 1987," +
				$" he was made a Commander of the Order of Arts and Letters in France, and he received the US" +
				$" Kennedy Center Honors lifetime achievement award in 1999.Connery was knighted in the " +
				$"2000 New Year Honours for services to film drama.[4]In 2004, Connery was polled in the " +
				$"Sunday Herald as The Greatest Living Scot[5] and " +
				$"in a 2011 EuroMillions survey as Scotland's Greatest Living National Treasure." +
				$"[6] He was voted by People magazine as the " +
				$"Sir Sean Connery(25 August 1930 – 31 October 2020) was a Scottish actor. " +
				$"He gained recognition as the first actor to portray fictional British secret agent " +
				$"James Bond in film, starring in seven Bond films between 1962 and 1983.[1][2][3] " +
				$"Originating the role in Dr. No, Connery played Bond in six of Eon Productions' " +
				$"entries and made his final appearance in the Jack Schwartzman-produced Never Say Never Again." +
				$"Connery began acting in smaller theatre and television productions until his breakout " +
				$"role as Bond.Although he did not enjoy the off-screen attention the role gave him, " +
				$"the success brought offers from famed film directors such as Alfred Hitchcock, " +
				$"Sidney Lumet and John Huston.Those films included Marnie(1964), The Hill(1965), " +
				$"Murder on the Orient Express(1974), The Man Who Would Be King(1975), A Bridge Too Far(1977)," +
				$" Highlander(1986), The Name of the Rose(1986), The Untouchables(1987), Indiana Jones and the " +
				$"Last Crusade(1989), The Hunt for Red October (1990), Dragonheart (1996), The Rock(1996), " +
				$"and Finding Forrester(2000).Connery officially retired from acting in 2006, although he" +
				$" briefly returned for voice over roles in 2012.His achievements in film were recognised " +
				$"with an Academy Award, two BAFTA Awards(including the BAFTA Fellowship), " +
				$"and three Golden Globes, including the Cecil B.DeMille Award and a Henrietta Award.In 1987," +
				$" he was made a Commander of the Order of Arts and Letters in France, and he received the US" +
				$" Kennedy Center Honors lifetime achievement award in 1999.Connery was knighted in the " +
				$"2000 New Year Honours for services to film drama.[4]In 2004, Connery was polled in the " +
				$"Sunday Herald as The Greatest Living Scot[5] and " +
				$"in a 2011 EuroMillions survey as Scotland's Greatest Living National Treasure." +
				$"[6] He was voted by People magazine as the" ;

			IEnumerable<char> reverseResult;

			reverseResult = str.Reverse();

			string result = "";
			foreach (char c in reverseResult)
			{
				result += c;
			}

			Console.WriteLine($"Revers  = {result}");
			Console.WriteLine($"Reversing string is completed at {DateTime.Now.ToString()} and taken" +
				$" {sw.Elapsed.TotalSeconds} Seconds to complete");

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
			Add(new Dept() { DeptNo = 201, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 202, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 203, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 204, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 205, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 206, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 207, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 208, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 209, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 210, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 211, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 212, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 213, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 214, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 215, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 216, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 217, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 218, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 219, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 220, DeptName = "Dept_101", Location = "Mumbai" });

			Add(new Dept() { DeptNo = 301, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 302, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 303, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 304, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 305, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 306, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 307, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 308, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 309, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 310, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 311, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 312, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 313, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 314, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 315, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 316, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 317, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 318, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 319, DeptName = "Dept_101", Location = "Mumbai" });
			Add(new Dept() { DeptNo = 320, DeptName = "Dept_101", Location = "Mumbai" });
		}
	}
}
