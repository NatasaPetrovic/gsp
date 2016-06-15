using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GSP.Startup))]
namespace GSP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
