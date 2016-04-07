using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MenusExample.Startup))]
namespace MenusExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
