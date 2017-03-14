using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Power.Startup))]
namespace Power
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
