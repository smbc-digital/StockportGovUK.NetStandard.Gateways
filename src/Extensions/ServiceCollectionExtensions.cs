using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using StockportGovUK.NetStandard.Gateways.Extensions.Models;

namespace StockportGovUK.NetStandard.Gateways.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IHttpClientBuilder AddHttpClient<TInterface, TImplementation>(this IServiceCollection services, IConfiguration configuration)
            where TInterface : class
            where TImplementation : class, TInterface
            => services.AddHttpClient<TInterface, TImplementation>(configuration, $"{typeof(TInterface).FullName.Split('.').Last()}Config");

        public static IHttpClientBuilder AddHttpClient<TInterface, TImplementation>(this IServiceCollection services, IConfiguration configuration, string configurationSection)
            where TInterface : class
            where TImplementation : class, TInterface
            => services.AddHttpClient<TInterface, TImplementation>(configuration.GetSection(configurationSection).Get<HttpClientConfiguration>());

        private static IHttpClientBuilder AddHttpClient<TInterface, TImplementation>(this IServiceCollection services, HttpClientConfiguration clientConfig)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            if (clientConfig == null)
            {
                throw new InvalidDataException($"Config section {typeof(TInterface).FullName.Split('.').Last()}Config not defined");
            }

            return services.AddHttpClient<TInterface, TImplementation>(client =>
                {
                    client.BaseAddress = string.IsNullOrEmpty(clientConfig.BaseUrl) ? null : new Uri(clientConfig.BaseUrl);
                    client.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(clientConfig?.AuthToken)
                        ? null
                        : AuthenticationHeaderValue.Parse(clientConfig.AuthToken);
                })
                .If(!string.IsNullOrEmpty(clientConfig.ProxyUrl), builder => 
                    builder.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() { 
                        Proxy = new WebProxy(clientConfig.ProxyUrl, clientConfig.ProxyPort) // e,g, new WebProxy("172.16.0.166", 8080)
                }))
                .If(clientConfig.EnablePollyPolicies, builder => builder
                    .AddPolicyHandler(GetWaitAndRetryForeverPolicy())
                    .AddPolicyHandler(GetCircuitBreakerPolicy()));
        }

        private static T If<T>(this T t, bool cond, Func<T, T> builder) => cond ? builder(t) : t;

        public static IAsyncPolicy<HttpResponseMessage> GetWaitAndRetryForeverPolicy() => HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryForeverAsync(retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy() => HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));
    }
}
