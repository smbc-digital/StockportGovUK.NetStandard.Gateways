using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Addresses;
using StockportGovUK.NetStandard.Models.Models.Verint;
using StockportGovUK.NetStandard.Models.Models.Verint.Update;

namespace StockportGovUK.AspNetCore.Gateways.VerintServiceGateway
{
    public interface IVerintServiceGateway
    {
        Task<HttpResponse<Case>> GetCase(string caseRef);

        Task<HttpResponseMessage> UpdateCaseIntegrationFormField(IntegrationFormFieldsUpdateModel content);

        Task<HttpResponse<string>> CreateCase(Case crmCase);

        Task<HttpResponse<List<AddressSearchResult>>> SearchForPropertyByPostcode(string postcode);
    }
}
