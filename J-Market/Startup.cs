using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(J_Market.Startup))]
namespace J_Market
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
