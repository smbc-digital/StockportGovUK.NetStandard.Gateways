using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUk.NetStandard.Models.ParkingEnforcement;

namespace StockportGovUK.AspNetCore.Gateways.ParkingEnforcement
{
    public interface IParkingEnforcementGateway : IGateway
    {
        Task<HttpResponseMessage> CreateCase(ParkingEnforcementRequest request);
    }
}