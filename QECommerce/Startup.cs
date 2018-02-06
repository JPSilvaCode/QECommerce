using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QECommerce.Startup))]
namespace QECommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
