using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Enums;
using StockportGovUK.NetStandard.Models.Models;
using StockportGovUK.NetStandard.Models.Models.Fostering;
using StockportGovUK.NetStandard.Models.Models.Fostering.HomeVisit;
using StockportGovUK.NetStandard.Models.Models.Fostering.Application;

namespace StockportGovUK.AspNetCore.Gateways.FosteringServiceGateway
{
    public class FosteringServiceGateway : Gateway, IFosteringServiceGateway
    {
        private const string HttpClientName = "fosteringServiceGateway";
        private const string CaseEndpoint = "api/v1/Case";
        private const string HomeVisitEndpoint = "api/v1/HomeVisit";
        private const string ApplicationEndpoint = "api/v1/Application";

        public FosteringServiceGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<HttpResponse<FosteringCase>> GetCase(string caseRef)
        {
            return await GetAsync<FosteringCase>(HttpClientName, $"{CaseEndpoint}/case?caseId={caseRef}");
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateAboutYourself(FosteringCaseAboutYourselfUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{HomeVisitEndpoint}/about-yourself", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateYourEmploymentDetails(FosteringCaseYourEmploymentDetailsUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{HomeVisitEndpoint}/your-employment-details", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateLanguagesSpokenInYourHome(FosteringCaseLanguagesSpokenInYourHomeUpdateModel model) {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{HomeVisitEndpoint}/languages-spoken-in-your-home", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateYourFosteringHistory(FosteringCaseYourFosteringHistoryUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{HomeVisitEndpoint}/your-fostering-history", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdatePartnershipStatus(FosteringCasePartnershipStatusUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{HomeVisitEndpoint}/partnership-status", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateYourHealthStatus(FosteringCaseHealthUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{HomeVisitEndpoint}/health-status", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateInterestInFostering(FosteringCaseInterestInFosteringUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{HomeVisitEndpoint}/interest-in-fostering", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateHousehold(FosteringCaseHouseholdUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{HomeVisitEndpoint}/update-household", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateChildrenLivingAwayFromHome(FosteringCaseChildrenLivingAwayFromHomeUpdateModel model) 
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{HomeVisitEndpoint}/children-living-away-from-home", model);
        }

        public async Task<HttpResponseMessage> UpdateFormStatus(NetStandard.Models.Models.Fostering.HomeVisit.FosteringCaseStatusUpdateModel model)
        {
            return await PatchAsync(HttpClientName, $"{HomeVisitEndpoint}/status", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateReferences(FosteringCaseReferenceUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{ApplicationEndpoint}/references", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateGpDetails(FosteringCaseGpDetailsUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{ApplicationEndpoint}/gp-details", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateAddressHistory(FosteringCaseAddressHistoryUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>(HttpClientName, $"{ApplicationEndpoint}/address-history", model);
        }

        public async Task<HttpResponseMessage> UpdateFormStatus(NetStandard.Models.Models.Fostering.Application.FosteringCaseStatusUpdateModel model)
        {
            return await PatchAsync(HttpClientName, $"{ApplicationEndpoint}/status", model);
        }
    }
}
