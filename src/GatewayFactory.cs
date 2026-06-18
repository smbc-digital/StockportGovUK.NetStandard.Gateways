using System;
using System.Net.Http;

public class GatewayFactory : IGatewayFactory
{
    private readonly IHttpClientFactory httpClientFactory;

    public GatewayFactory(IHttpClientFactory httpClientFactory) 
        => this.httpClientFactory = httpClientFactory;
    
    public T Create<T>(string clientName) where T : class  
        => (T)Activator.CreateInstance(typeof(T), httpClientFactory.CreateClient(clientName));
    
}