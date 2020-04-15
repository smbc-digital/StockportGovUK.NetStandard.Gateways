using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Polly.CircuitBreaker;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StockportGovUK.NetStandard.Gateways.Tests.Unit
{
    public class GatewayTests
    {
        private readonly Gateway _gateway;
        private readonly Mock<ILogger<Gateway>> _mockLogger = new Mock<ILogger<Gateway>>();
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        private readonly HttpClient _httpClient;

        public GatewayTests()
        {
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://test.stockport.gov.uk")
            };

            _gateway = new Gateway(_httpClient, _mockLogger.Object);
        }

        [Fact]
        public async void Invoke_ShouldReturnResponse()
        {
            // Arrange
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK
                })
                .Verifiable();

            // Act
            await _gateway.Invoke<Task<HttpResponseMessage>>(async requestUrl => await _httpClient.GetAsync(It.IsAny<string>()), It.IsAny<string>(), It.IsAny<string>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public void Invoke_BrokenCircuitException()
        {
            //    //// Arrange
            //    //_mockHttpMessageHandler
            //    //    .Protected()
            //    //    .Setup<Task<HttpResponseMessage>>(
            //    //        "SendAsync",
            //    //          ItExpr.IsAny<HttpRequestMessage>(),
            //    //        ItExpr.IsAny<CancellationToken>()
            //    //    )
            //    //    .Throws(new BrokenCircuitException($"Test Invoke_BrokenCircuitException - Circuit broken"))
            //    //    .Verifiable();


            //    //// Act
            //    //await _gateway.Invoke<Task<HttpResponseMessage>>(async requestUrl => await _httpClient.GetAsync(It.IsAny<string>()), It.IsAny<string>(), It.IsAny<string>());


            //    //// Assert
            //    //_mockHttpMessageHandler
            //    //    .Protected()
            //    //    .Verify(
            //    //        "SendAsync",
            //    //        Times.Once(),
            //    //        ItExpr.IsAny<HttpRequestMessage>(),
            //    //        ItExpr.IsAny<CancellationToken>()
            //    //    );

            var ex = Assert.ThrowsAsync<BrokenCircuitException<HttpResponseMessage>>(() => _gateway.Invoke<Task<HttpResponseMessage>>(async requestUrl => await _httpClient.GetAsync(It.IsAny<string>()), It.IsAny<string>(), It.IsAny<string>()));
            Assert.Contains(ex.Result.Message.ToString(), "Circuit broken due to");
        }
    }
}