using Microsoft.Owin;
using Owin;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(WebApplication.Startup))]

namespace WebApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use((context, next) =>
            {
                var testHeader = new KeyValuePair<string, string[]>("test-header", new string[] { "asdasdasd" });

                context.Response.Headers.Add(testHeader);


                return next();
            });
        }
    }
}
