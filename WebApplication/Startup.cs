using Microsoft.Owin;
using Owin;
using WebApplication.Middleware;

[assembly: OwinStartup(typeof(WebApplication.Startup))]

namespace WebApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseTestHeader();
        }
    }
}
