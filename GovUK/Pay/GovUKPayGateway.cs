using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.GovUK.Pay
{
    public class GovUKPayGateway: Gateway, IGovUKPayGateway
    {

        private const string DD_ROOT = "v1/directdebit";
        public GovUKPayGateway(HttpClient client) : base(client)
        {
        }

        public async Task<SimpleMandateSetupResponse> SetupMandateAsync(MandateSetupRequest request)
        {
            var url = $"{DD_ROOT}/mandates";
            var response = await PostAsync<GovUkMandateSetupResponse>(url, request);
            var simpleResponse = new SimpleMandateSetupResponse(response.ResponseContent);
            return simpleResponse;
        }
    }
}