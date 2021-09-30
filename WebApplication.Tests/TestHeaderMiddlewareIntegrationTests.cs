using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Owin.Testing;
using Xunit;

namespace WebApplication.Tests
{
    public class TestHeaderMiddlewareIntegrationTests
    {
        [Fact]
        public async Task TestGoodMethod()
        {
            using (var server = TestServer.Create<Startup>())
            {
                var response = await server.HttpClient.GetAsync("/");

                response.Headers.Contains("test-header").Should().BeTrue();
            }
        }
    }
}
