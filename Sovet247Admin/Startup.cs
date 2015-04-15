using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sovet247Admin.Startup))]
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
