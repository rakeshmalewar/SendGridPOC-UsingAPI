using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SendGrid_WebAPI_POC.Startup))]
namespace SendGrid_WebAPI_POC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
