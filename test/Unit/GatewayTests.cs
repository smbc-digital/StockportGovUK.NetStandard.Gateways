using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Polly.CircuitBreaker;
using Xunit;

namespace StockportGovUK.NetStandard.Gateways.Tests.Unit
{
    public class GatewayTests
    {
        private readonly Gateway _gateway;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        private const string BaseAddress = "https://test.stockport.gov.uk";
        private const string TestUrl = "/test/endpoint";

        public GatewayTests()
        {
            var httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri(BaseAddress)
            };

            _gateway = new Gateway(httpClient);
        }

        [Fact]
        public async void ChangeAuthenticationHeader_ShouldChangeAuthenticationHeader()
        {
            // Arrange
            const string testHeader = "TestHeader";
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
            _gateway.ChangeAuthenticationHeader(testHeader);
            await _gateway.GetAsync(It.IsAny<string>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Headers.Authorization.ToString() == testHeader),
                    ItExpr.IsAny<CancellationToken>()
                );
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
                .ReturnsAsync(new HttpResponseMessage())
                .Verifiable();

            // Act
            await _gateway.GetAsync(It.IsAny<string>());

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

            Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.GetAsync(It.IsAny<string>()));
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

            Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.GetAsync(It.IsAny<string>()));
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
            Assert.ThrowsAsync<Exception>(() => _gateway.GetAsync(TestUrl));
        }

        [Fact]
        public async void Invoke_GivenHttpClientThrowsBrokenCircuitTypedException_ShouldDisplayErrorMessage()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.GetAsync(TestUrl));

            //Assert
            Assert.Contains(TestUrl, ex.Message);
            Assert.Contains("GetAsync", ex.Message);
            Assert.Contains("Circuit open", ex.Message);
        }

        [Fact]
        public async void Invoke_GivenHttpClientThrowsBrokenCircuitException_ShouldDisplayErrorMessage()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.GetAsync(TestUrl));

            //Assert
            Assert.Contains(TestUrl, ex.Message);
            Assert.Contains("GetAsync", ex.Message);
            Assert.Contains("Circuit open", ex.Message);
        }

        [Fact]
        public async void Invoke_GivenHttpClientThrowsException_ShouldDisplayErrorMessage()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.GetAsync(TestUrl));

            //Assert
            Assert.Contains(TestUrl, ex.Message);
            Assert.Contains("GetAsync", ex.Message);
            Assert.Contains("Circuit open", ex.Message);
        }

        [Fact]
        public async void GetAsync_ShouldCallHttpClient()
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
            await _gateway.GetAsync(TestUrl);

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void GetAsync_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.GetAsync(TestUrl));

            //Assert
            Assert.Contains("GetAsync", ex.Message);
        }

        [Fact]
        public async void GetAsyncTyped_ShouldCallHttpClient()
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
            await _gateway.GetAsync<HttpResponseMessage>(TestUrl);

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void GetAsyncTyped_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.GetAsync<HttpResponseMessage>(TestUrl));

            //Assert
            Assert.Contains("GetAsync", ex.Message);
        }

        [Fact]
        public async void PatchAsync_ShouldCallHttpClient()
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
            await _gateway.PatchAsync(TestUrl, It.IsAny<object>(), It.IsAny<bool>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void PatchAsync_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.PatchAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<bool>()));

            //Assert
            Assert.Contains("PatchAsync", ex.Message);
        }

        [Fact]
        public async void PatchAsyncObject_ShouldCallHttpClient()
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
            await _gateway.PatchAsync(It.IsAny<object>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void PatchAsyncObject_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.PatchAsync(It.IsAny<object>()));

            //Assert
            Assert.Contains("PatchAsync", ex.Message);
        }

        [Fact]
        public async void PatchAsyncStringObject_ShouldCallHttpClient()
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
            await _gateway.PatchAsync(TestUrl, It.IsAny<object>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void PatchAsyncStringObject_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.PatchAsync(TestUrl, It.IsAny<object>()));

            //Assert
            Assert.Contains("PatchAsync", ex.Message);
        }

        [Fact]
        public async void PatchAsyncTyped_ShouldCallHttpClient()
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
            await _gateway.PatchAsync<HttpResponseMessage>(TestUrl, It.IsAny<object>(), It.IsAny<bool>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void PatchAsyncTyped_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.PatchAsync<HttpResponseMessage>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<bool>()));

            //Assert
            Assert.Contains("PatchAsync", ex.Message);
        }

        [Fact]
        public async void PatchAsyncTypedObject_ShouldCallHttpClient()
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
            await _gateway.PatchAsync<HttpResponseMessage>(TestUrl, It.IsAny<object>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void PatchAsyncTypedObject_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.PatchAsync<HttpResponseMessage>(It.IsAny<string>(), It.IsAny<object>()));

            //Assert
            Assert.Contains("PatchAsync", ex.Message);
        }

        [Fact]
        public async void PostAsync_ShouldCallHttpClient()
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
            await _gateway.PostAsync(TestUrl, It.IsAny<object>(), It.IsAny<bool>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void PostAsync_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.PostAsync(TestUrl, It.IsAny<object>(), It.IsAny<bool>()));

            //Assert
            Assert.Contains("PostAsync", ex.Message);
        }

        [Fact]
        public async void PostAsyncStringObject_ShouldCallHttpClient()
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
            await _gateway.PostAsync(TestUrl, It.IsAny<object>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void PostAsyncStringObject_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.PostAsync(TestUrl, It.IsAny<object>()));

            //Assert
            Assert.Contains("PostAsync", ex.Message);
        }

        [Fact]
        public async void PostAsyncTyped_ShouldCallHttpClient()
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
            await _gateway.PostAsync<HttpResponseMessage>(TestUrl, It.IsAny<object>(), It.IsAny<bool>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void PostAsyncTyped_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.PostAsync<HttpResponseMessage>(TestUrl, It.IsAny<object>(), It.IsAny<bool>()));

            //Assert
            Assert.Contains("PostAsync", ex.Message);
        }

        [Fact]
        public async void PostAsyncTypedObjectString_ShouldCallHttpClient()
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
            await _gateway.PostAsync<HttpResponseMessage>(TestUrl, It.IsAny<object>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void PostAsyncTypedObjectString_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.PostAsync<HttpResponseMessage>(TestUrl, It.IsAny<object>()));

            //Assert
            Assert.Contains("PostAsync", ex.Message);
        }

        [Fact]
        public async void PutAsync_ShouldCallHttpClient()
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
            await _gateway.PutAsync(TestUrl, It.IsAny<HttpContent>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void PutAsync_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.PutAsync(TestUrl, It.IsAny<HttpContent>()));

            //Assert
            Assert.Contains("PutAsync", ex.Message);
        }

        [Fact]
        public async void PutAsyncTyped_ShouldCallHttpClient()
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
            await _gateway.PutAsync<HttpResponseMessage>(TestUrl, It.IsAny<HttpContent>(), It.IsAny<bool>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void PutAsyncTyped_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.PutAsync<HttpResponseMessage>(TestUrl, It.IsAny<HttpContent>(), It.IsAny<bool>()));

            //Assert
            Assert.Contains("PutAsync", ex.Message);
        }

        [Fact]
        public async void PutAsyncTypedObjectString_ShouldCallHttpClient()
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
            await _gateway.PutAsync<HttpResponseMessage>(TestUrl, It.IsAny<HttpContent>());

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void PutAsyncTypedStringObject_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.PutAsync<HttpResponseMessage>(TestUrl, It.IsAny<HttpContent>()));

            //Assert
            Assert.Contains("PutAsync", ex.Message);
        }

        [Fact]
        public async void DeleteAsync_ShouldCallHttpClient()
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
            await _gateway.DeleteAsync(TestUrl);

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void DeleteAsyncTyped_ShouldCallHttpClient()
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
            await _gateway.DeleteAsync<HttpResponseMessage>(TestUrl);

            // Assert
            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri == new Uri($"{BaseAddress}{TestUrl}")),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async void DeleteAsyncTyped_GivenExceptionThrown_ShouldReturnExceptionWithCorrectRequestType()
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

            //Act
            var ex = await Assert.ThrowsAsync<BrokenCircuitException>(() => _gateway.DeleteAsync<HttpResponseMessage>(TestUrl));

            //Assert
            Assert.Contains("DeleteAsync", ex.Message);
        }
    }
}