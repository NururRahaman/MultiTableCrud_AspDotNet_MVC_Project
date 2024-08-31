using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MultiTableCrud.Startup))]
namespace MultiTableCrud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
