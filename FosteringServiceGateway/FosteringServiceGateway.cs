using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Enums;
using StockportGovUK.NetStandard.Models.Models;
using StockportGovUK.NetStandard.Models.Models.Fostering;
using StockportGovUK.NetStandard.Models.Models.Fostering.Update;

namespace StockportGovUK.AspNetCore.Gateways.FosteringServiceGateway
{
    public class FosteringServiceGateway : Gateway, IFosteringServiceGateway
    {
        private const string HttpClientName = "fosteringServiceGateway";
        private const string CaseEndpoint = "api/v1/Fostering";

        public FosteringServiceGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<HttpResponse<FosteringCase>> GetCase(string caseRef)
        {
            return await GetAsync<FosteringCase>(HttpClientName, $"{CaseEndpoint}/case?caseId={caseRef}");
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateAboutYourself(FosteringCaseAboutYourselfUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{CaseEndpoint}/about-yourself", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateYourEmploymentDetails(FosteringCaseYourEmploymentDetailsUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{CaseEndpoint}/your-employment-details", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateLanguagesSpokenInYourHome(FosteringCaseLanguagesSpokenInYourHomeUpdateModel model) {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{CaseEndpoint}/languages-spoken-in-your-home", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateYourFosteringHistory(FosteringCaseYourFosteringHistoryUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{CaseEndpoint}/your-fostering-history", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdatePartnershipStatus(FosteringCasePartnershipStatusUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{CaseEndpoint}/partnership-status", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateYourHealthStatus(FosteringCaseHealthUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{CaseEndpoint}/health-status", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateInterestInFostering(FosteringCaseInterestInFosteringUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{CaseEndpoint}/interest-in-fostering", model);
        }

        public async Task<HttpResponseMessage> UpdateFormStatus(FosteringCaseStatusUpdateModel model)
        {
            return await PatchAsync(HttpClientName, $"{CaseEndpoint}/update-form-status", model);
        }
    }
}
