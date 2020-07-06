<h1 align="center">StockportGovUK.NetStandard.Gateways</h1>

<div align="center">
  :computer::door::rainbow:
</div>
<div align="center">
  <strong>Wonders lie ahead</strong>
</div>
<div align="center">
  A common approach to talking to third party applications for StockportGovUK applications
</div>

<br />

<div align="center">
  <img src="https://img.shields.io/nuget/dt/StockportGovUK.NetStandard.Gateways.svg?style=flat-square" />
  <img src="https://img.shields.io/nuget/v/StockportGovUK.NetStandard.Gateways.svg?style=flat-square" />
  <img src="https://img.shields.io/badge/stability-stable-green.svg?style=flat-square" />
</div>

<div align="center">
  <h3>
    External Links
    <a href="https://github.com/smbc-digital/StockportGovUK.NetStandard.Gateways">
      GitHub
    </a>
    <span> | </span>
    <a href="https://www.nuget.org/packages/StockportGovUK.NetStandard.Gateways/">
      NuGet
    </a>
  </h3>
</div>

<div align="center">
  <sub>Built with ❤︎ by
  <a href="https://www.stockport.gov.uk">Stockport Council</a> and
  <a href="">
    contributors
  </a>
</div>

## Table of Contents
- [Features](#features)
- [Example](#example)
- [Philosophy](#philosophy)
- [Service Gateways](#service-gateways)
- [Installation](#installation)

## Features
- __Common approach:__ shared methods and a common fallback for gateways

## Example
```c#
var response = await _gateway.GetCase(caseId);
```

## Philosophy
We have always had need to use Gateways within our applications and had so many times we were copying and pasting the same files over to allow the same functionality. Finally enough was enough and we decided to encapsulate all of this functionality into A shared NuGet package with a set default for our applications

## Service Gateways
Using a micro service architechture we wanted an easy way for services to expose their endpoints to any of our other services. In place or remembering the exact URL for a specific endpoint these gateways provide that information for the developer.

Within your application configuration you define the base URL for your service, allowing you to overide it per environment if you want to point to a test system.

This config is then used within the Gateway pacakge to route the request to the correct endpoint.

```json
"IGatewayConfig": {
  "BaseUrl": "http://service.stockport.gov.uk/",
  "AuthToken": "TestToken",
  "EnablePollyPolicies": "false"
}
```

Adding resilient clients (i.e. with circuit breaker) is now done via the gateways package (rather than through [polly](https://github.com/smbc-digital/StockportGovUK.NetStandard.Polly). To enable this behaviour add the following to startup.

```C#
services.AddHttpClient<IGateway, Gateway>(Configuration);
```

To use a gateway simply inject that gateway into the consumer.
```C#
public HomeController(IYourGatewayName gateway)
```

New gateways are constructed slightly differently, the following pattern is a gateway and example get request

```c#
    public class MyNewGateway : Gateway, IMyNewGateway
    {
        public MyNewGateway(HttpClient httpClient) : base(httpClient) 
        {
        }

        public async Task<HttpResponseMessage> DoSomethingAsync(string data)
        {
            var url = $"/api/v1/endpoint/{data}";
            return await GetAsync(url);
        }
```

## Installation
```bash
$ dotnet add package StockportGovUK.NetStandard.Gateways
```

## License
[MIT](https://tldrlegal.com/license/mit-license)
