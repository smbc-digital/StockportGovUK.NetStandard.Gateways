using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.GovUKPay.Models.Request;
using StockportGovUK.NetStandard.Gateways.GovUKPay.Models.Response;

namespace StockportGovUK.NetStandard.Gateways.GovUKPay
{
    public class GovUKPayGateway : Gateway, IGovUKPayGateway
    {

        private const string DD_ROOT = "v1/directdebit";
        public GovUKPayGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<SimpleMandateSetupResponse> SetupMandateAsync(MandateSetupRequest request)
        {
            var url = $"{DD_ROOT}/mandates";
            var response = await PostAsync<GovUkMandateSetupResponse>(url, request);
            var simpleResponse = new SimpleMandateSetupResponse(response.ResponseContent);
            return simpleResponse;
        }

        public async Task<SimpleMandateStatusResponse> CheckMandateStatusAsync(string mandateId)
        {
            var url = $"{DD_ROOT}/mandates/{mandateId}";
            var response = await GetAsync<GovUkMandateStatusResponse>(url);
            var mandateStatusResponse = new SimpleMandateStatusResponse(response.ResponseContent);
            return mandateStatusResponse;
        }
    }
}