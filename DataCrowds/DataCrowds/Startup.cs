using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataCrowds.Startup))]
namespace DataCrowds
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
