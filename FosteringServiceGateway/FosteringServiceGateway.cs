using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Enums;
using StockportGovUK.NetStandard.Models.Models;
using StockportGovUK.NetStandard.Models.Models.Fostering;
using StockportGovUK.NetStandard.Models.Models.Fostering.HomeVisit;
using StockportGovUK.NetStandard.Models.Models.Fostering.Application;
using Microsoft.Extensions.Logging;

namespace StockportGovUK.NetStandard.Gateways.FosteringServiceGateway
{
    public class FosteringServiceGateway : Gateway, IFosteringServiceGateway
    {
        private const string CaseEndpoint = "api/v1/Case";

        private const string HomeVisitEndpoint = "api/v1/HomeVisit";

        private const string ApplicationEndpoint = "api/v1/Application";

        public FosteringServiceGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {
        }

        public async Task<HttpResponse<FosteringCase>> GetCase(string caseRef)
        {
            return await GetAsync<FosteringCase>($"{CaseEndpoint}/case?caseId={caseRef}");
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateAboutYourself(FosteringCaseAboutYourselfUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/about-yourself", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateYourEmploymentDetails(FosteringCaseYourEmploymentDetailsUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/your-employment-details", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateLanguagesSpokenInYourHome(FosteringCaseLanguagesSpokenInYourHomeUpdateModel model) {
            return await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/languages-spoken-in-your-home", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateYourFosteringHistory(FosteringCaseYourFosteringHistoryUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/your-fostering-history", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdatePartnershipStatus(FosteringCasePartnershipStatusUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/partnership-status", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateYourHealthStatus(FosteringCaseHealthUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/health-status", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateInterestInFostering(FosteringCaseInterestInFosteringUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/interest-in-fostering", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateHousehold(FosteringCaseHouseholdUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/update-household", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateChildrenLivingAwayFromHome(FosteringCaseChildrenLivingAwayFromHomeUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/children-living-away-from-home", model);
        }

        public async Task<HttpResponseMessage> UpdateFormStatus(NetStandard.Models.Models.Fostering.HomeVisit.FosteringCaseStatusUpdateModel model)
        {
            return await PatchAsync($"{HomeVisitEndpoint}/status", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateReferences(FosteringCaseReferenceUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>($"{ApplicationEndpoint}/references", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateGpDetails(FosteringCaseGpDetailsUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>($"{ApplicationEndpoint}/gp-details", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateAddressHistory(FosteringCaseAddressHistoryUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>($"{ApplicationEndpoint}/address-history", model);
        }

        public async Task<HttpResponse<ETaskStatus>> UpdateCouncillorsOrEmployees(FosteringCaseCouncillorsUpdateModel model)
        {
            return await PatchAsync<ETaskStatus>($"{ApplicationEndpoint}/councillors-details", model);
        }

        public async Task<HttpResponseMessage> UpdateFormStatus(NetStandard.Models.Models.Fostering.Application.FosteringCaseStatusUpdateModel model)
        {
            return await PatchAsync($"{ApplicationEndpoint}/status", model);
        }
    }
}
