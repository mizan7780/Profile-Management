using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProfileManagement.Startup))]
namespace ProfileManagement
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
