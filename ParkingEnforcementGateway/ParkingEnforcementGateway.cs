using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockportGovUk.NetStandard.Models.ParkingEnforcement;

namespace StockportGovUK.AspNetCore.Gateways.ParkingEnforcement
{
    public class ParkingEnforcementGateway : Gateway, IParkingEnforcementGateway
    {
        const string CaseEndpoint = "/api/v1";

        public ParkingEnforcementGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {

        }

        public async Task<HttpResponseMessage> CreateCase(ParkingEnforcementRequest request)
        {
            return await PostAsync($"{CaseEndpoint}/Home", request);
        }
    }
}