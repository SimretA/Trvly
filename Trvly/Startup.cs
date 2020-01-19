using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trvly.Startup))]
namespace Trvly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
