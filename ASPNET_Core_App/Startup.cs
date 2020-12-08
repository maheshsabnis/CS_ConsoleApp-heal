using ASPNET_Core_App.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_Core_App.Models;
using ASPNET_Core_App.Repositories;
using ASPNET_Core_App.CustomFilters;
using ASPNET_Core_App.CustomMiddlewares;

namespace ASPNET_Core_App
{
	public class Startup
	{

		/// <summary>
		/// Injected with IConfiguration contract interface
		/// This interface reads appsettings.json for 
		/// Any application level configuration
		/// e.g. ConnectionString
		/// </summary>
		/// <param name="configuration"></param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.

		/// <summary>
		/// The method accepts IServiceCollection contract interface
		/// This interface creates a "Default Dependency Container"
		/// to register all depednencies for the applciation
		/// e.g. Database Connection, Custom Developer Repositores
		/// Sessions, Caching, Security, CORS policy,
		/// MVC Controllers, WebForm Razor Views and API Controlles request
		/// processing
		/// and many more things
		/// IServiceCollection, interface uses ServiceDescriptor class
		/// This class is responsible for registering all 
		/// Services (aka dependencies) in Dependency Contains (D.I.)
		/// with pre-defined lifetime of instance of each service as below
		/// Singleton: Only one instance is created throught life time of application
		/// Scope : A new object of dependency is created per session
		/// Transient: For each new request the instance of the depednency is created
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
		{
			// registertion of Security Database Connection string
			// in depednency
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));

			// service for Providing User registration of Login
			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();

			// register the RHealDbCOntext  in DI Container
			// a new connection object will be created for
			// every new session (Scopped)
			// this will read the connectionstring 
			// from the appsettings.json
			// and connect to database
			services.AddDbContext<RHealDbContext>(options=> {
				options.UseSqlServer(Configuration.GetConnectionString("RHealDbConnection"));
			});

			// register repositories in DI Cotainer as Scopped
			services.AddScoped<IBizRepository<Categories,int>, CategoryBizRepository>();
			services.AddScoped<IBizRepository<Products, int>, ProductBizRepository>();


			// add service for session       
			// on server-side the session infromation / session data is stored in
			// cache memory
			services.AddDistributedMemoryCache();
			services.AddSession(session => {
				// if no request in timeout span the session will be terminated
				// and all session data will be cleared
				session.IdleTimeout = TimeSpan.FromMinutes(20);
			});


			// service to accept request for MVC and API COntrollers
			// and views
			services.AddControllersWithViews(options=> {
				// registering the Action Filters
				// typeof(ErrorFilter) will instantiate the action filter
				// and AUTO-RESOLVE its depednencies e.g. IModelMetadataProvider
			//	options.Filters.Add(typeof(ErrorFilter));  // filter is commented because Middlewre dor exception is written
			}).AddJsonOptions(options=> {
				// AddJsonOpetions() method define the format for JSON serialization
				// and default is camelCasing.
				// the options.JsonSerializerOptions.PropertyNamingPolicy = null; 
				// will supress the default policy for the serializarion 
				options.JsonSerializerOptions.PropertyNamingPolicy = null;
			});
			// service to accept request for Razor WebForms
			// NOte: in ASP.NET Core 3.0+
			// All Identity Views e.g. Register, Login, etc.
			// are web form aka RazorPages
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to 
		//configure the HTTP request pipeline.

		/// <summary>
		/// THis method is for HTTP Request Processing
		/// This method uses 
		/// IWebHostEnvironment: Contract for host configure initialization
		/// e.g. IIS, Apache, nGinx
		/// IApplicationBuilder: This is the contarct used for
		/// Registering all middlewares for
		/// Executing, 
		/// Application Level Exceptions, 
		/// Mapping Http request to Https Request
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				// application level database exception middleware
				app.UseDeveloperExceptionPage();
				// standard application level error page in
				// development enviorment
				app.UseDatabaseErrorPage();
			}
			else
			{
				// in hosting production
				// error page
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			// redirect or map Http request to Https request middleware
			app.UseHttpsRedirection();
			// middlweare for Static files e.g. jQuery, CSS, images, etc.
			// these will be loaded in browser for validations
			// these files are read from wwwwroot folder
			app.UseStaticFiles();
			// middleware for evaluting routing
			// MVC Controller and its action method
			// as well as form API Controllers with  Http GET /POST/ PUT and DELETE
			app.UseRouting();

			// use the session
			app.UseSession();


			// For Security
			app.UseAuthentication();
			app.UseAuthorization();

			// register the Custom Exception Middlware
			app.UseCustomExceptionMiddleware();



			// Publish the ASP.NET Core app
			// on Endpoint so that the request 
			// will be accepted from Hosting env. e,g. IIS
			// and will be processed top execute MVC COntroller / API COntroller
			// otr Razor Page using UseEndpoint middleware
			app.UseEndpoints(endpoints =>
			{
				// MVC  COntrollers
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				// for Razor Web Forms e.g. Security Pages
				// Register or Login etc.
				endpoints.MapRazorPages();
			});
		}
	}
}
