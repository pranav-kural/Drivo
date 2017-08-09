using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Drivo.Startup))]
namespace Drivo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
