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

        public override Task Invoke(IOwinContext context)
        {
            var testHeader = new KeyValuePair<string, string[]>("test-header", new string[] { "asdasdasd" });

            context.Response.Headers.Add(testHeader);

            return next.Invoke(context);
        }
    }
}