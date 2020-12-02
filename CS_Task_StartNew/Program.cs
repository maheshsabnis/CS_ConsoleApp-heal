using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS_Task_StartNew
{
	class Program
	{
		static void Main(string[] args)
		{
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
				$"[6] He was voted by People magazine as the ";

			Task<string> task = Task.Factory.StartNew<string>(() =>
			{
				return ReverseString(str);
			});
			//	task.Wait();
			
			// Retriving the result from the task

			Console.WriteLine($"The reverse is = {task.Result}");
			Console.ReadLine();
		}

		/// <summary>
		/// Method is returning the Task
		/// </summary>
		/// <param name="information"></param>
		/// <returns></returns>
		static string ReverseString(string information)
		{
			IEnumerable<char> reverseResult;

			reverseResult =  information.Reverse();

			string result = "";
			foreach (char c in reverseResult)
			{
				result += c;
			}

			return   result;
		}
	}
}
