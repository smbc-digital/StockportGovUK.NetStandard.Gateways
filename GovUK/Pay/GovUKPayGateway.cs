using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StockportGovUK.AspNetCore.Gateways.GovUK.Pay
{
    public class GovUKPayGateway: Gateway, IGovUKPayGateway
    {

        private const string DD_ROOT = "v1/directdebit";
        public GovUKPayGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
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