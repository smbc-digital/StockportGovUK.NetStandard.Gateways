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
        public async void Invoke_ShouldCallHttpClient()
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
            await _gateway.InvokeAsync<HttpResponseMessage>(async requestUrl => await _httpClient.GetAsync(It.IsAny<string>()), It.IsAny<string>(), It.IsAny<string>());

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
        public void Invoke_GivenHttpClientThrowsBrokenCircuitExceptionTyped_ShouldThrowBrokenCircuitException()
        {
            // Arrange
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Throws(new BrokenCircuitException<HttpResponseMessage>(new HttpResponseMessage()));

            Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.InvokeAsync<HttpResponseMessage>(requestUrl => _httpClient.GetAsync(It.IsAny<string>()), It.IsAny<string>(), It.IsAny<string>()));
        }

        [Fact]
        public void Invoke_GivenHttpClientThrowsBrokenCircuitException_ShouldThrowBrokenCircuitException()
        {
            // Arrange
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Throws(new BrokenCircuitException());

            Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.InvokeAsync<HttpResponseMessage>(requestUrl => _httpClient.GetAsync(It.IsAny<string>()), It.IsAny<string>(), It.IsAny<string>()));
        }

        [Fact]
        public void Invoke_GivenHttpClientThrowsException_ShouldThrowException()
        {
            // Arrange
            _mockHttpMessageHandler
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.IsAny<HttpRequestMessage>(),
                   ItExpr.IsAny<CancellationToken>()
               )
               .Throws(new Exception());

            //Assert
            Assert.ThrowsAsync<Exception>(() => _gateway.InvokeAsync<HttpResponseMessage>(requestUrl => _httpClient.GetAsync(It.IsAny<string>()), It.IsAny<string>(), It.IsAny<string>()));
        }

        [Fact]
        public async void Invoke_GivenHttpClientThrowsBrokenCircuitTypedException_ShouldDisplayErrorMessage()
        {
            // Arrange
            const string Url = "https://text.stockport.gov.uk/testmessage";
            const string RequestType = "testType";

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Throws(new BrokenCircuitException<HttpResponseMessage>(new HttpResponseMessage()));

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.InvokeAsync<HttpResponseMessage>(requestUrl => _httpClient.GetAsync(It.IsAny<string>()), Url, RequestType));

            //Assert
            Assert.Contains(Url, ex.Message);
            Assert.Contains(RequestType, ex.Message);
            Assert.Contains("Circuit broken due to:", ex.Message);
        }

        [Fact]
        public async void Invoke_GivenHttpClientThrowsBrokenCircuitException_ShouldDisplayErrorMessage()
        {
            // Arrange
            const string Url = "https://text.stockport.gov.uk/testmessage";
            const string RequestType = "testType";

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Throws(new BrokenCircuitException());

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.InvokeAsync<HttpResponseMessage>(requestUrl => _httpClient.GetAsync(It.IsAny<string>()), Url, RequestType));

            //Assert
            Assert.Contains(Url, ex.Message);
            Assert.Contains(RequestType, ex.Message);
            Assert.Contains("Circuit broken due to:", ex.Message);
        }

        [Fact]
        public async void Invoke_GivenHttpClientThrowsException_ShouldDisplayErrorMessage()
        {
            // Arrange
            const string Url = "https://text.stockport.gov.uk/testmessage";
            const string RequestType = "testType";

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Throws(new Exception());

            //Act
            var ex = await Assert.ThrowsAsync<Exception>(() => _gateway.InvokeAsync<HttpResponseMessage>(requestUrl => _httpClient.GetAsync(It.IsAny<string>()), Url, RequestType));

            //Assert
            Assert.Contains(Url, ex.Message);
            Assert.Contains(RequestType, ex.Message);
            Assert.Contains("failed with the following error:", ex.Message);
        }

        //Create test method to make sure the invoke function is called.

        //Create test method to make sure the requestType is correct
    }
}