using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUk.NetStandard.Models.ParkingEnforcement;

namespace StockportGovUK.NetStandard.Gateways.ParkingEnforcement
{
    public interface IParkingEnforcementGateway : IGateway
    {
        Task<HttpResponseMessage> CreateCase(ParkingEnforcementRequest request);
    }
}