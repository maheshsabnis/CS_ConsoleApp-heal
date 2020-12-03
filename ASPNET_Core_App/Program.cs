using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_App
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		/// <summary>
		/// Initialize the Hosting Env.
		/// Load the Statup class for
		/// 1. Defining the Sessions
		/// 2. Initialization of the Database Connection
		/// 3. Initializing the Application Identity
		/// 4. Initialiozing the Caching
		/// 5. Initializing Custom Dependencies aka Repository classes
		/// The Host uses the 'Self-Hosted' aka .exe engine 
		/// known as 'Kestral'
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
