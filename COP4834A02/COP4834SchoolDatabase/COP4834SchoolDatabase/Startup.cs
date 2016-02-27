using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(COP4834SchoolDatabase.Startup))]
namespace COP4834SchoolDatabase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
