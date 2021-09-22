using Owin;
using System.Collections.Generic;

namespace WebApplication.Middleware
{
    public static class AppBuilderExtensions
    {
        public static void UseTestHeader(this IAppBuilder app)
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