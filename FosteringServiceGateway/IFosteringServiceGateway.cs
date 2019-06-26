using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Enums;
using StockportGovUK.NetStandard.Models.Models.Fostering;
using StockportGovUK.NetStandard.Models.Models.Fostering.Update;

namespace StockportGovUK.AspNetCore.Gateways.FosteringServiceGateway
{
    public interface IFosteringServiceGateway
    {
        Task<HttpResponse<FosteringCase>> GetCase(string caseRef);

        Task<HttpResponse<ETaskStatus>> UpdateAboutYourself(FosteringCaseAboutYourselfUpdateModel model);

        Task<HttpResponse<ETaskStatus>> UpdateYourEmploymentDetails(FosteringCaseYourEmploymentDetailsUpdateModel model);

        Task<HttpResponse<ETaskStatus>> UpdateLanguagesSpokenInYourHome(FosteringCaseLanguagesSpokenInYourHomeUpdateModel model);
       
        Task<HttpResponse<ETaskStatus>> UpdatePartnershipStatus(FosteringCasePartnershipStatusUpdateModel model);

        Task<HttpResponseMessage> UpdateFormStatus(FosteringCaseStatusUpdateModel model);
    }
}
