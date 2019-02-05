using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CNV_Site.Startup))]
namespace CNV_Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
