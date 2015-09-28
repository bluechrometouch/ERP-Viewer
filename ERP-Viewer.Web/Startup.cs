using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERP_Viewer.Web.Startup))]
namespace ERP_Viewer.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
