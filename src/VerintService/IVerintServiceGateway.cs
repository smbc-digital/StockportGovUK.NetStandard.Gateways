using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Addresses;
using StockportGovUK.NetStandard.Models.Verint;
using StockportGovUK.NetStandard.Models.Verint.Lookup;
using StockportGovUK.NetStandard.Models.Verint.Update;

namespace StockportGovUK.NetStandard.Gateways.VerintService
{
    public interface IVerintServiceGateway
    {
        Task<HttpResponse<Case>> GetCase(string caseRef);
        Task<HttpResponseMessage> UpdateCaseIntegrationFormField(IntegrationFormFieldsUpdateModel content);
        Task<HttpResponse<int>> UpdateCaseDescription(Case crmCase);
        Task<HttpResponse<string>> CreateCase(Case crmCase);
        Task<HttpResponse<List<AddressSearchResult>>> SearchForPropertyByPostcode(string postcode);
        Task<HttpResponse<List<AddressSearchResult>>> GetStreetByReference(string street);
        Task<HttpResponse<List<OrganisationSearchResult>>> SearchForOrganisationByName(string organisation);
        Task<HttpResponseMessage> AddNoteWithAttachments(NoteWithAttachments model);
    }
}
