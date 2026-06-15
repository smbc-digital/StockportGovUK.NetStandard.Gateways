using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockportGovUK.NetStandard.Gateways.Extensions;
using Xunit;

namespace StockportGovUK.NetStandard.Gateways.Tests.Unit
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddKeyedHttpClient_ShouldRegisterTypedClientForTheSpecifiedKey()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["TestGatewayConfig:BaseUrl"] = "https://example.com"
                })
                .Build();

            services.AddKeyedHttpClient<ITestGateway, TestGateway>(configuration, "primary", "TestGatewayConfig");

            using var serviceProvider = services.BuildServiceProvider();

            var gateway = serviceProvider.GetRequiredService<ITestGateway>();

            Assert.NotNull(gateway);
        }

        private interface ITestGateway
        {
        }

        private class TestGateway : ITestGateway
        {
            public TestGateway(HttpClient client)
            {
                Client = client;
            }

            public HttpClient Client { get; }
        }
    }
}
