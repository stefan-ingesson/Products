using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductMVC.Startup))]
namespace ProductMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
