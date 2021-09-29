using Microsoft.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Middleware
{
    public class TestHeaderMiddleware : OwinMiddleware
    {
        private readonly OwinMiddleware next;

        public TestHeaderMiddleware(OwinMiddleware next) : base(next)
        {
            this.next = next;
        }

        public override async Task Invoke(IOwinContext context)
        {
            await next.Invoke(context);

            var testHeader = new KeyValuePair<string, string[]>("test-header", new string[] { "asdasdasd" });

            context.Response.Headers.Add(testHeader);
        }
    }
}