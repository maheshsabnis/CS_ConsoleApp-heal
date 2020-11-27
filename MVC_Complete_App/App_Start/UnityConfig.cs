using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC_Complete_App.BizRepositories;
using MVC_Complete_App.Controllers;
using MVC_Complete_App.Models;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace MVC_Complete_App
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            // Register all BizRepositories
            
            
            // Register Account Controller and all its dependencies
            // e.g. Identity classes in DI Container 
          container.RegisterType<AccountController>(new InjectionConstructor());

            // register the ApplicationDbContext
            container.RegisterType<ApplicationDbContext>();

            container.RegisterType<IBizRepository<Category,int>, CategoryBizRepository>();
            container.RegisterType<IBizRepository<Product,int>, ProductBizRepository>();
            // These dependencies will be resolved when a client application (Controller)
            // wants these instances injected in it
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}