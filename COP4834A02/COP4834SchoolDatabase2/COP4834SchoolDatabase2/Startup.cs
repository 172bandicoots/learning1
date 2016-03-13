using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(COP4834SchoolDatabase2.Startup))]
namespace COP4834SchoolDatabase2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
