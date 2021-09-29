using System.Threading.Tasks;
using WebApplication.Middleware;
using Xunit;
using Microsoft.Owin;
using Moq;
using FluentAssertions;
using System.Collections.Generic;

namespace WebApplication.Tests
{
    public class TestHeaderMiddlewareTests
    {
        private readonly Mock<OwinMiddleware> _mockNextOwinMiddleware;

        public TestHeaderMiddlewareTests()
        {
            _mockNextOwinMiddleware = new Mock<OwinMiddleware>((OwinMiddleware)null);

            _mockNextOwinMiddleware.Setup(arg => arg.Invoke(It.IsAny<IOwinContext>())).Returns(Task.CompletedTask);

        }

        [Fact]
        public async Task TestHeaderMiddleware_AddsHeaderToResponse()
        {
            // Arrange
            var middlewareInstance = new TestHeaderMiddleware(_mockNextOwinMiddleware.Object);
            var owinContext = GetMockOwinContext();
            
            // Act
            await middlewareInstance.Invoke(owinContext);

            // Assert
            owinContext.Response.Headers.ContainsKey("test-header").Should().BeTrue();
        }

        private static IOwinContext GetMockOwinContext()
        {
            var requestMock = new Mock<IOwinRequest>();
            requestMock.SetupGet(m => m.Scheme).Returns("https");
            requestMock.SetupGet(m => m.Path).Returns(new PathString("/"));
            requestMock.SetupGet(m => m.Method).Returns("GET");

            var responseMock = new Mock<IOwinResponse>();
            responseMock.SetupGet(m => m.Headers).Returns(new HeaderDictionary(new Dictionary<string, string[]>()));
            
            var owinContextMock = new Mock<IOwinContext>();
            owinContextMock.SetupGet(m => m.Request).Returns(requestMock.Object);
            owinContextMock.SetupGet(m => m.Response).Returns(responseMock.Object);

            return owinContextMock.Object;
        }
    }
}
