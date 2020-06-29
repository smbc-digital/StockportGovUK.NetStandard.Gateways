using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.GovUKPay.Models.Request;
using StockportGovUK.NetStandard.Gateways.GovUKPay.Models.Response;

namespace StockportGovUK.NetStandard.Gateways.GovUKPay
{
    public interface IGovUKPayGateway
    {
        Task<SimpleMandateSetupResponse> SetupMandateAsync(MandateSetupRequest request);

        Task<SimpleMandateStatusResponse> CheckMandateStatusAsync(string mandateId);
    }
}