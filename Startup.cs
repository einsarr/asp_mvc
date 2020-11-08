using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DepartementEmploye.Startup))]
namespace DepartementEmploye
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
