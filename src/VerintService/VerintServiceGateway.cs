using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace StockportGovUK.NetStandard.Gateways.VerintService
{
    public partial class VerintServiceGateway : Gateway, IVerintServiceGateway
    {
        private readonly ILogger<VerintServiceGateway> _logger;
        public VerintServiceGateway(HttpClient httpClient, ILogger<VerintServiceGateway> logger) : base(httpClient)
        {
            _logger = logger;
        }
    }
}
