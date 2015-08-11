using Microsoft.Owin;
using Owin;
using Sovet247Admin;

[assembly: OwinStartup(typeof(Startup))]
namespace Sovet247Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
