using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WotDifferWebApplication.Startup))]
namespace WotDifferWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
