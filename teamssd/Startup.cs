using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(teamssd.Startup))]
namespace teamssd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
