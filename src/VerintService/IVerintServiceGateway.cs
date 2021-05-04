using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Addresses;
using StockportGovUK.NetStandard.Models.Models.Verint.VerintOnlineForm;
using StockportGovUK.NetStandard.Models.Verint;
using StockportGovUK.NetStandard.Models.Verint.Lookup;
using StockportGovUK.NetStandard.Models.Verint.Update;
using Address = StockportGovUK.NetStandard.Models.Verint.Address;

namespace StockportGovUK.NetStandard.Gateways.VerintService
{
    public interface IVerintServiceGateway
    {
        Task<HttpResponse<Case>> GetCase(string caseRef);
        Task<HttpResponseMessage> UpdateCaseIntegrationFormField(IntegrationFormFieldsUpdateModel content);
        Task<HttpResponse<bool>> AddCaseFormField(AddCaseFormFieldRequest request);
        Task<HttpResponse<int>> UpdateCaseDescription(Case crmCase);
        Task<HttpResponse<string>> CreateCase(Case crmCase);
        Task<HttpResponse<string>> CloseCase(CloseCaseRequest closeCaseRequest);
        Task<HttpResponse<VerintOnlineFormResponse>> CreateVerintOnlineFormCase(VerintOnlineFormRequest verintOnlineFormRequest);
        Task<HttpResponse<List<AddressSearchResult>>> SearchForPropertyByPostcode(string postcode);
        Task<HttpResponse<Address>> GetPropertyByUprn(string uprn);
        Task<HttpResponse<List<AddressSearchResult>>> GetStreetByReference(string street);
        Task<HttpResponse<List<AddressSearchResult>>> GetStreetByUsrn(string usrn);
        Task<HttpResponse<AddressSearchResult>> GetStreet(string reference);
        Task<HttpResponse<List<OrganisationSearchResult>>> SearchForOrganisationByName(string organisation);
        Task<HttpResponseMessage> AddNoteWithAttachments(NoteWithAttachments model);
        Task<HttpResponseMessage> AddNote(NoteRequest model);
    }
}
