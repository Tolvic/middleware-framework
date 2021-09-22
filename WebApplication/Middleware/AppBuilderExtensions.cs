using Owin;
using System.Collections.Generic;

namespace WebApplication.Middleware
{
    public static class AppBuilderExtensions
    {
        public static void UseTestHeader(this IAppBuilder app)
        {
            app.Use<TestHeaderMiddleware>();
        }
    }
}