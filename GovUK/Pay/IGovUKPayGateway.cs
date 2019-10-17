using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.GovUK.Pay
{
    public interface IGovUKPayGateway
    {
        Task<HttpResponse<MandateSetupResponse>> SetupMandateAsync(MandateSetupRequest request);
    }
}