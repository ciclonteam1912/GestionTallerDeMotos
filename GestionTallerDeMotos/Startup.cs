using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionTallerDeMotos.Startup))]
namespace GestionTallerDeMotos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
