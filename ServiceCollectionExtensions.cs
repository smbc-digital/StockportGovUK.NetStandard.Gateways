using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Polly;
using Polly.Extensions.Http;
using Polly.Fallback;

namespace StockportGovUK.AspNetCore.Gateways
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHttpClients<TClient, TImplementation>(this IServiceCollection services, IConfiguration configuration)
            where TClient : class
            where TImplementation : class, TClient
        {
            AddBaseHttpClient<TClient, TImplementation>(services);

            var httpClientConfiguration = configuration.GetSection("HttpClientConfiguration").GetChildren();
            foreach (var config in httpClientConfiguration)
            {
                if(string.IsNullOrEmpty(config["name"]))
                {
                    throw new Exception("Name for HttpClient not specified");
                }
                
                AddHttpClients(services, config["name"], c => 
                {
                    c.BaseAddress = string.IsNullOrEmpty(config["baseUrl"]) ? null : new Uri(config["baseUrl"]);

                    c.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(config["authToken"])
                        ? null 
                        : new AuthenticationHeaderValue("Bearer", config["authToken"]);
                });
            }
        }

        public static void AddResilientHttpClients<TClient, TImplementation>(this IServiceCollection services, IConfiguration configuration)
            where TClient : class
            where TImplementation : class, TClient
        {
            AddBaseHttpClient<TClient, TImplementation>(services);

            var httpClientConfiguration = configuration.GetSection("HttpClientConfiguration")?.GetChildren();

            if (httpClientConfiguration != null) {
                foreach (var config in httpClientConfiguration)
                {
                    if(string.IsNullOrEmpty(config["gatewayType"]) || string.IsNullOrEmpty(config["iGatewayType"]))
                    {
                        throw new Exception("Gateway Type for HttpClient not specified");
                    }

                    var addPollyPolicies = true;
                    var addPollyPoliciesConfig = config["addPollyPolicies"];
                    if(!string.IsNullOrEmpty(addPollyPoliciesConfig))
                    {
                        bool.TryParse(addPollyPoliciesConfig, out addPollyPolicies);
                    }
                    
                    AddResilientHttpClients(services, config["gatewayType"], config["iGatewayType"], addPollyPolicies, c => 
                    {
                        c.BaseAddress = string.IsNullOrEmpty(config["baseUrl"]) ? null : new Uri(config["baseUrl"]);
                        c.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(config["authToken"])
                            ? null 
                            : AuthenticationHeaderValue.Parse(config["authToken"]);
                    });
                }
            }
        }
        
        private static void AddBaseHttpClient<TClient, TImplementation>(this IServiceCollection services)
            where TClient : class
            where TImplementation : class, TClient
        {
            services.AddHttpClient<TClient, TImplementation>()
                .AddPolicies();
        }

        private static void AddHttpClients(IServiceCollection services, string name, Action<HttpClient> config)
        {
            services.AddHttpClient(name, config)
                .AddPolicies();
        }

        private static void AddResilientHttpClients(IServiceCollection services, string gatewayType, string iGatewayType, bool addPollyPolicies, Action<HttpClient> config)
        {
            var reflectedType = typeof(HttpClientFactoryServiceCollectionExtensions);
            if(reflectedType==null)
            {
                throw new Exception("Reflected type was null");
            }

            var reflectedMethod = reflectedType
                            .GetMethods()
                            .Where(_ => _.Name=="AddHttpClient" 
                                && _.IsGenericMethod 
                                && _.IsStatic
                                && _.GetGenericArguments().Count()==2 
                                && _.GetParameters().Count()==2
                            )
                            .Skip(1)
                            .First();

            var clientType = Type.GetType(gatewayType);   
            var iClientType = clientType.GetInterface(iGatewayType);

            MethodInfo invokeableMethod = reflectedMethod.MakeGenericMethod(iClientType, clientType);
            var invokedMethod = (IHttpClientBuilder)invokeableMethod.Invoke(null, new object[] { services, config });
            if(addPollyPolicies)
            {
                invokedMethod.AddPolicies();
            }
        }

        public static void AddPolicies(this IHttpClientBuilder clientBuilder)
        {
            clientBuilder
                .AddPolicyHandler(GetDefaultRetryPolicy())
                .AddPolicyHandler(GetDefaultCircuitBreakerPolicy());
        }

        public static IAsyncPolicy<HttpResponseMessage> GetDefaultRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                );
        }

        public static IAsyncPolicy<HttpResponseMessage> GetDefaultCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30));
        }
    }
}
