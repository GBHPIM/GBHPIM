using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GBHPIM.Startup))]
namespace GBHPIM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
