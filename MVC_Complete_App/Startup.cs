using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Complete_App.Startup))]
namespace MVC_Complete_App
{

    /// <summary>
    ///  class that is used to initialize the User's Authentication Process
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
