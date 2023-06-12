using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Addresses;
using StockportGovUK.NetStandard.Gateways.Models.Verint;
using StockportGovUK.NetStandard.Gateways.Models.Verint.Lookup;
using StockportGovUK.NetStandard.Gateways.Models.Verint.Update;
using StockportGovUK.NetStandard.Gateways.Models.Verint.VerintOnlineForm;
using StockportGovUK.NetStandard.Gateways.Response;
using Address = StockportGovUK.NetStandard.Gateways.Models.Verint.Address;

namespace StockportGovUK.NetStandard.Gateways.VerintService
{
    public interface IVerintServiceGateway
    {
        Task<HttpResponse<Case>> GetCase(string caseRef);
        Task<HttpResponseMessage> UpdateCaseIntegrationFormField(IntegrationFormFieldsUpdateModel content);
        Task<HttpResponse<bool>> AddCaseFormField(AddCaseFormFieldRequest request);
        Task<HttpResponse<int>> UpdateCaseDescription(Case crmCase);
        Task<HttpResponse<string>> CreateCase(Case crmCase);
        Task<HttpResponseMessage> LinkCase(LinkCaseRequest linkCaseRequest);
        Task<HttpResponseMessage> UnLinkCase(LinkCaseRequest unLinkCaseRequest);
        Task<HttpResponse<string>> CloseCase(CloseCaseRequest closeCaseRequest);
        Task<HttpResponseMessage> ReopenCase(ReopenCaseRequest reopenCaseRequest);
        Task CleanupCase(string caseRef);
        Task<HttpResponse<VerintOnlineFormResponse>> CreateVerintOnlineFormCase(VerintOnlineFormRequest verintOnlineFormRequest);
        Task<HttpResponse<VerintOnlineFormResponse>> AttachVerintOnlineFormToCase(VerintOnlineFormRequest verintOnlineFormRequest);
        Task<HttpResponse<List<AddressSearchResult>>> SearchForPropertyByPostcode(string postcode);
        Task<HttpResponse<Address>> GetPropertyByUprn(string uprn);
        Task<HttpResponse<Address>> GetPropertyFromUprn(string uprn);
        Task<HttpResponse<List<AddressSearchResult>>> GetStreetByReference(string street);
        Task<HttpResponse<List<AddressSearchResult>>> GetStreetByUsrn(string usrn);
        Task<HttpResponse<AddressSearchResult>> GetStreet(string reference);
        Task<HttpResponse<List<OrganisationSearchResult>>> SearchForOrganisationByName(string organisation);
        Task<HttpResponseMessage> AddNoteWithAttachments(NoteWithAttachments model);
        Task<HttpResponseMessage> AddNote(NoteRequest model);
        Task<HttpResponse<int>> UpdateCaseTitle(Case crmCase);
    }
}
