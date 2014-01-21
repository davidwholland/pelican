using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pelican.Startup))]
namespace Pelican
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
