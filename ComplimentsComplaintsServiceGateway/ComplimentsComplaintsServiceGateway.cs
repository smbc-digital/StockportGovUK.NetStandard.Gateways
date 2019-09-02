using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Enums;
using StockportGovUK.NetStandard.Models.Models;
using StockportGovUK.NetStandard.Models.Models.Fostering;
using StockportGovUK.NetStandard.Models.Models.Fostering.HomeVisit;
using StockportGovUK.NetStandard.Models.Models.Fostering.Application;

namespace StockportGovUK.AspNetCore.Gateways.ComplimentsComplaintsGateway
{
    public class ComplimentsComplaintsGateway : Gateway, IComplimentsComplaintsGateway
    {
        private const string HttpClientName = "complimentsComplaintsGateway";
        private const string ComplimentEndpoint = "api/v1/Compliment";

        public ComplimentsComplaintsGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<ComplimentsComplaintsResponse> SubmitCompliment(ComplimentDetails model)
        {
            return await PostAsync(HttpClientName, $"{ComplimentEndpoint}/submit-compliment", model);
        }
    }
}