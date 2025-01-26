using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EternalElegance.Startup))]
namespace EternalElegance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
