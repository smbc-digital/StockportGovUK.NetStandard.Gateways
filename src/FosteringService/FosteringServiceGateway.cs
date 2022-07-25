using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Enums;
using StockportGovUK.NetStandard.Gateways.Models;
using StockportGovUK.NetStandard.Gateways.Models.Fostering;
using StockportGovUK.NetStandard.Gateways.Models.Fostering.Application;
using StockportGovUK.NetStandard.Gateways.Models.Fostering.HomeVisit;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.FosteringService
{
    public class FosteringServiceGateway : Gateway, IFosteringServiceGateway
    {
        private const string CaseEndpoint = "api/v1/Case";

        private const string HomeVisitEndpoint = "api/v1/HomeVisit";

        private const string ApplicationEndpoint = "api/v1/Application";

        public FosteringServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponse<FosteringCase>> GetCase(string caseRef)
            => await GetAsync<FosteringCase>($"{CaseEndpoint}/case?caseId={caseRef}");

        public async Task<HttpResponse<ETaskStatus>> UpdateAboutYourself(FosteringCaseAboutYourselfUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/about-yourself", model);

        public async Task<HttpResponse<ETaskStatus>> UpdateYourEmploymentDetails(FosteringCaseYourEmploymentDetailsUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/your-employment-details", model);

        public async Task<HttpResponse<ETaskStatus>> UpdateLanguagesSpokenInYourHome(FosteringCaseLanguagesSpokenInYourHomeUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/languages-spoken-in-your-home", model);

        public async Task<HttpResponse<ETaskStatus>> UpdateYourFosteringHistory(FosteringCaseYourFosteringHistoryUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/your-fostering-history", model);

        public async Task<HttpResponse<ETaskStatus>> UpdatePartnershipStatus(FosteringCasePartnershipStatusUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/partnership-status", model);

        public async Task<HttpResponse<ETaskStatus>> UpdateYourHealthStatus(FosteringCaseHealthUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/health-status", model);

        public async Task<HttpResponse<ETaskStatus>> UpdateInterestInFostering(FosteringCaseInterestInFosteringUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/interest-in-fostering", model);

        public async Task<HttpResponse<ETaskStatus>> UpdateHousehold(FosteringCaseHouseholdUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/update-household", model);

        public async Task<HttpResponse<ETaskStatus>> UpdateChildrenLivingAwayFromHome(FosteringCaseChildrenLivingAwayFromHomeUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{HomeVisitEndpoint}/children-living-away-from-home", model);

        public async Task<HttpResponseMessage> UpdateFormStatus(Models.Fostering.HomeVisit.FosteringCaseStatusUpdateModel model)
            => await PatchAsync($"{HomeVisitEndpoint}/status", model);

        public async Task<HttpResponse<ETaskStatus>> UpdateReferences(FosteringCaseReferenceUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{ApplicationEndpoint}/references", model);

        public async Task<HttpResponse<ETaskStatus>> UpdateGpDetails(FosteringCaseGpDetailsUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{ApplicationEndpoint}/gp-details", model);

        public async Task<HttpResponse<ETaskStatus>> UpdateAddressHistory(FosteringCaseAddressHistoryUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{ApplicationEndpoint}/address-history", model);

        public async Task<HttpResponse<ETaskStatus>> UpdateCouncillorsOrEmployees(FosteringCaseCouncillorsUpdateModel model)
            => await PatchAsync<ETaskStatus>($"{ApplicationEndpoint}/councillors-details", model);

        public async Task<HttpResponseMessage> UpdateFormStatus(Models.Fostering.Application.FosteringCaseStatusUpdateModel model)
            => await PatchAsync($"{ApplicationEndpoint}/status", model);
    }
}
