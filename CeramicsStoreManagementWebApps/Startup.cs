using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CeramicsStoreManagementWebApps.Startup))]
namespace CeramicsStoreManagementWebApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
