using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LojaOnline.Startup))]
namespace LojaOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
