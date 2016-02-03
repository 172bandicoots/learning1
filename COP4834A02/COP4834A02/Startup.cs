using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(COP4834A02.Startup))]
namespace COP4834A02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
