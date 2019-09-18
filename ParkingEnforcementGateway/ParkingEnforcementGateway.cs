using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUk.NetStandard.Models.ParkingEnforcement;

namespace StockportGovUK.AspNetCore.Gateways.ParkingEnforcement
{
    public class ParkingEnforcementGateway : Gateway, IParkingEnforcementGateway
    {
        const string CaseEndpoint = "/api/v1";

        public ParkingEnforcementGateway(HttpClient httpClient) : base(httpClient) 
        {

        }

        public async Task<HttpResponseMessage> CreateCase(ParkingEnforcementRequest request)
        {
            return await PostAsync($"{CaseEndpoint}/Home", request);
        }
    }
}