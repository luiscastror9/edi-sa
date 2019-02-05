using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CofcoInd.Startup))]
namespace CofcoInd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
