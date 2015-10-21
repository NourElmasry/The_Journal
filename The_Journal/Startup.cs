using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(The_Journal.Startup))]
namespace The_Journal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
