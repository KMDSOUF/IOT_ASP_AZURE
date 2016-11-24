using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Yourlake_Azure.Startup))]
namespace Yourlake_Azure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
