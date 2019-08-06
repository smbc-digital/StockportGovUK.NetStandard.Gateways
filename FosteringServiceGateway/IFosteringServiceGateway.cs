using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Enums;
using StockportGovUK.NetStandard.Models.Models;
using StockportGovUK.NetStandard.Models.Models.Fostering;
using StockportGovUK.NetStandard.Models.Models.Fostering.Application;
using StockportGovUK.NetStandard.Models.Models.Fostering.HomeVisit;

namespace StockportGovUK.AspNetCore.Gateways.FosteringServiceGateway
{
    public interface IFosteringServiceGateway
    {
        Task<HttpResponse<FosteringCase>> GetCase(string caseRef);

        Task<HttpResponse<ETaskStatus>> UpdateAboutYourself(FosteringCaseAboutYourselfUpdateModel model);

        Task<HttpResponse<ETaskStatus>> UpdateYourEmploymentDetails(FosteringCaseYourEmploymentDetailsUpdateModel model);

        Task<HttpResponse<ETaskStatus>> UpdateLanguagesSpokenInYourHome(FosteringCaseLanguagesSpokenInYourHomeUpdateModel model);
       
        Task<HttpResponse<ETaskStatus>> UpdatePartnershipStatus(FosteringCasePartnershipStatusUpdateModel model);

        Task<HttpResponseMessage> UpdateFormStatus(NetStandard.Models.Models.Fostering.HomeVisit.FosteringCaseStatusUpdateModel model);

        Task<HttpResponseMessage> UpdateFormStatus(NetStandard.Models.Models.Fostering.Application.FosteringCaseStatusUpdateModel model);

        Task<HttpResponse<ETaskStatus>> UpdateYourFosteringHistory(FosteringCaseYourFosteringHistoryUpdateModel model);

        Task<HttpResponse<ETaskStatus>> UpdateYourHealthStatus(FosteringCaseHealthUpdateModel model);

        Task<HttpResponse<ETaskStatus>> UpdateInterestInFostering(FosteringCaseInterestInFosteringUpdateModel model);

        Task<HttpResponse<ETaskStatus>> UpdateHousehold(FosteringCaseHouseholdUpdateModel model);

        Task<HttpResponse<ETaskStatus>> UpdateChildrenLivingAwayFromHome(FosteringCaseChildrenLivingAwayFromHomeUpdateModel model);

        Task<HttpResponse<ETaskStatus>> UpdateGpDetails(FosteringCaseGpDetailsUpdateModel model);

        Task<HttpResponse<ETaskStatus>> UpdateReferences(FosteringCaseReferenceUpdateModel model);
    }
}
