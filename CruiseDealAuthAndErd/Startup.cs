using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CruiseDealAuthAndErd.Startup))]
namespace CruiseDealAuthAndErd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
