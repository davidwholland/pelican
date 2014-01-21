using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pelican.Startup))]
namespace pelican
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
