using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.GovUK.Pay
{
    public interface IGovUKPayGateway
    {
        Task<SimpleMandateSetupResponse> SetupMandateAsync(MandateSetupRequest request);
    }
}