using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Alkemy.Startup))]
namespace Alkemy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
