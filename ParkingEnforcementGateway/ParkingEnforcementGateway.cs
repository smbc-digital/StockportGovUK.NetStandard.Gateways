using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.ParkingEnforcement
{
    public class ParkingEnforcementGateway : Gateway, IParkingEnforcementGateway
    {
        public ParkingEnforcementGateway(HttpClient httpClient) : base(httpClient) 
        {

        }

        public async Task<HttpResponseMessage> CreateCase(ParkingEnforcementRequest request)
        {
            var url = $"/api/v1/Home";
            return await PostAsync(url);
        }
    }
}