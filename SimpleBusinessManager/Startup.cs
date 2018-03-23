using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleBusinessManager.Startup))]
namespace SimpleBusinessManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
