using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Addresses;
using StockportGovUK.NetStandard.Gateways.Models.Verint;
using StockportGovUK.NetStandard.Gateways.Models.Verint.Lookup;
using StockportGovUK.NetStandard.Gateways.Models.Verint.Update;
using StockportGovUK.NetStandard.Gateways.Models.Verint.VerintOnlineForm;
using Address = StockportGovUK.NetStandard.Gateways.Models.Verint.Address;

namespace StockportGovUK.NetStandard.Gateways.VerintService
{
    public interface IVerintServiceGateway
    {
        #region Case

        Task<Case> GetCase(string caseRef);
        Task<string> CreateCase(Case crmCase);
        Task LinkCase(LinkCaseRequest linkCaseRequest);
        Task LinkCase(LinkCaseRequest linkCaseRequest, bool logOnly);
        Task UnLinkCase(LinkCaseRequest unLinkCaseRequest);
        Task UnLinkCase(LinkCaseRequest unLinkCaseRequest, bool logOnly);
        Task<string> CloseCase(CloseCaseRequest closeCaseRequest);
        Task<string> CloseCase(CloseCaseRequest closeCaseRequest, bool logOnly);
        Task ReopenCase(ReopenCaseRequest reopenCaseRequest);
        Task ReopenCase(ReopenCaseRequest reopenCaseRequest, bool logOnly);
        Task CleanupCase(CloseCaseRequest closeCaseRequest);
        Task CleanupCase(CloseCaseRequest closeCaseRequest, bool logOnly);
        Task<int> UpdateCaseDescription(Case crmCase);
        Task<int> UpdateCaseDescription(Case crmCase, bool logOnly);
        Task<int> UpdateCaseQueue(Case crmCase);
        Task<int> UpdateCaseQueue(Case crmCase, bool logOnly);
        Task<int> UpdateCaseTitle(Case crmCase);
        Task<int> UpdateCaseTitle(Case crmCase, bool logOnly);
        Task UpdateCaseIntegrationFormField(IntegrationFormFieldsUpdateModel content);
        Task UpdateCaseIntegrationFormField(IntegrationFormFieldsUpdateModel content, bool logOnly);
        Task<bool> AddCaseFormField(AddCaseFormFieldRequest request);
        Task<bool> AddCaseFormField(AddCaseFormFieldRequest request, bool logOnly);
        Task AddNoteWithAttachments(NoteWithAttachments model);
        Task AddNoteWithAttachments(NoteWithAttachments model, bool logOnly);
        Task AddNote(NoteRequest model);
        Task AddNote(NoteRequest model, bool logOnly);

        #endregion

        #region Verint Online Form

        Task<VerintOnlineForm> GetVerintOnlineFormCase(string verintOnlineFormReference);
        Task<VerintOnlineFormResponse> CreateVerintOnlineFormCase(VerintOnlineFormRequest verintOnlineFormRequest);
        Task<VerintOnlineFormResponse> AttachVerintOnlineFormToCase(VerintOnlineFormRequest verintOnlineFormRequest);
        Task UpdateVerintOnlineFormFormData(VerintOnlineFormUpdateRequest request);
        Task UpdateVerintOnlineFormFormData(VerintOnlineFormUpdateRequest request, bool logOnly);

        #endregion

        #region Property

        Task<List<AddressSearchResult>> SearchForPropertyByPostcode(string postcode);
        Task<Address> GetPropertyByPlaceRef(string placeRef);
        Task<Address> GetPropertyFromUprn(string uprn);

        #endregion

        #region Street

        Task<List<AddressSearchResult>> GetStreetByReference(string street);
        Task<List<AddressSearchResult>> GetStreetByUsrn(string usrn);
        Task<List<AddressSearchResult>> SearchForPropertyByUsrn(string usrn);
        Task<AddressSearchResult> GetStreet(string reference);

        #endregion

        #region Organisation

        Task<List<OrganisationSearchResult>> SearchForOrganisationByName(string organisation);

        #endregion
    }
}
