using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.GovUK.Pay
{
    public interface IGovUKPayGateway
    {
        Task<SimpleMandateSetupResponse> SetupMandateAsync(MandateSetupRequest request);

        Task<SimpleMandateStatusResponse> CheckMandateStatusAsync(string mandateId);
    }
}