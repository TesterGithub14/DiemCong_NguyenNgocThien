using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NguyenNgocThien.Startup))]
namespace NguyenNgocThien
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
