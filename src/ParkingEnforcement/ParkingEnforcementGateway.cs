using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUk.NetStandard.Gateways.Models.ParkingEnforcement;

namespace StockportGovUK.NetStandard.Gateways.ParkingEnforcement
{
    public class ParkingEnforcementGateway : Gateway, IParkingEnforcementGateway
    {
        const string CaseEndpoint = "/api/v1";

        public ParkingEnforcementGateway(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<HttpResponseMessage> CreateCase(ParkingEnforcementRequest request)
            => await PostAsync($"{CaseEndpoint}/Home", request);
    }
}