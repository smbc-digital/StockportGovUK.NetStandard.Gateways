using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Models.Fostering;
using StockportGovUK.NetStandard.Models.Models.Fostering.Update;

namespace StockportGovUK.AspNetCore.Gateways.FosteringServiceGateway
{
    public interface IFosteringServiceGateway
    {
        Task<HttpResponse<FosteringCase>> GetCase(string caseRef);

        Task<HttpResponseMessage> UpdateAboutYourself(FosteringCaseAboutYourselfUpdateModel model);

        Task<HttpResponseMessage> UpdateYourEmploymentDetails(FosteringCaseYourEmploymentDetailsUpdateModel model);

        Task<HttpResponseMessage> UpdateFormStatus(FosteringCaseStatusUpdateModel model);
    }
}
