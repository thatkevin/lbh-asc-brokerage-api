using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;

namespace BrokerageApi.Tests.V1.Controllers.Mocks
{
    internal class MockProblemDetailsFactory : Mock<ProblemDetailsFactory>
    {
        public MockProblemDetailsFactory()
        {
            Setup(x => x.CreateProblemDetails(
                    It.IsAny<HttpContext>(),
                    It.IsAny<int?>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns<HttpContext, int?, string, string, string, string>((httpContext, statusCode, title, type, detail, instance) => new ProblemDetails
                {
                    Status = statusCode
                });
        }

        public void VerifyStatusCode(HttpStatusCode statusCode)
        {
            Verify(x => x.CreateProblemDetails(
                It.IsAny<HttpContext>(),
                (int) statusCode,
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()));
        }
    }
}
