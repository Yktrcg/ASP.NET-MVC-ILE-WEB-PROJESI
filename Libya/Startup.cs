using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Libya.Startup))]
namespace Libya
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
